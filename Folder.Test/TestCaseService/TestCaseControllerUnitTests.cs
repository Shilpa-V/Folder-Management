using FolderManagement.Controllers;
using FolderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FolderManager.Test.TestCaseService
{
   public class TestCaseControllerUnitTests
    {

        TestCaseController _controller;
        ITestCaseRepository _serviceTest;
        IFolderRepository _serviceFolder;
        ILogger<TestCaseController> _logger;

        public TestCaseControllerUnitTests()
        {
            var serviceProvider = new ServiceCollection()
                                   .AddLogging()
                                   .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            _logger = factory.CreateLogger<TestCaseController>();

            _serviceTest = new TestcaseServiceFake();
            _serviceFolder = new FolderServiceFake();
            _controller = new TestCaseController(_serviceTest, _serviceFolder, _logger);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnBadRequest()
        {
            //Arrange
            var nameMissingTestCase = new TestCase()
            {

                TestCaseType = TestCaseType.API,
                StepCount = 1,
                FolderId = null,
            };

            _controller.ModelState.AddModelError("Name", "Required");

            //Act
            var badResponse = _controller.Create(nameMissingTestCase);

            //Assert
            Assert.IsType<RedirectToActionResult>(badResponse);

        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponseRedirected()
        {
            //Arrange
            TestCase newtestCase = new TestCase()
            {
                Name = "Test1",
                TestCaseType = TestCaseType.API,
                StepCount = 3,
                FolderId = 2,
            };

            //Act
            var createdResponse = _controller.Create(newtestCase);
            IEnumerable<TestCase> totalTestCases = _serviceTest.GetAllTestCases(2);

            //Assert 
            Assert.IsType<RedirectToActionResult>(createdResponse);
            Assert.Single(totalTestCases);

        }

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 5;

            // Act
            var badResponse = _controller.ConfirmDelete(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingId = 1;

            // Act
            var okResponse = _controller.ConfirmDelete(existingId);

            // Assert
            Assert.IsType<RedirectToActionResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 1;

            // Act
            var okResponse = _controller.ConfirmDelete(existingId);

            // Assert
            Assert.Equal(2, _serviceTest.GetAllTestCases(null).Count());
        }

    }
}
