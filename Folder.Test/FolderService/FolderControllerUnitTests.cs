using FolderManagement.Controllers;
using FolderManagement.Models;
using FolderManager.Test;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Folder.Test
{
    public class FolderControllerUnitTests
    {
        HomeController _controller;
        IFolderRepository _service;
        ILogger <HomeController> _logger;

        public FolderControllerUnitTests()
        {
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            _logger = factory.CreateLogger<HomeController>();

            _service = new FolderServiceFake();
            _controller = new HomeController(_service, _logger);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnBadRequest()
        {
            //Arrange
            var nameMissingFolder = new FolderManagement.Models.Folder()
            {

                ParentFolderId = null
            };

            _controller.ModelState.AddModelError("Name", "Required");

            //Act
            var badResponse = _controller.Create(nameMissingFolder);

            //Assert
            Assert.IsType<ViewResult>(badResponse);

        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponseRedirected()
        {
            //Arrange
            FolderManagement.Models.Folder testFolder = new FolderManagement.Models.Folder()
            {

                ParentFolderId = 1,
                Name = "TestFolder"
            };

            //Act
            var createdResponse = _controller.Create(testFolder) ;
            IEnumerable <FolderManagement.Models.Folder> totalFolders =  _service.GetAllFolders();
                      
           //Assert 
            Assert.IsType<RedirectToActionResult>(createdResponse);
            Assert.Equal(6, totalFolders.Count());
           
        }

             
    }
}
