using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FolderManagement.Models;
using Microsoft.Extensions.Logging;

namespace FolderManagement.Controllers
{
    // Controller to manage Home Page and Folder related Actions
    public class HomeController : Controller
    {
        private readonly IFolderRepository _folderRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IFolderRepository folderRepository, ILogger<HomeController> logger)
        {
            _folderRepository = folderRepository;
            _logger = logger;
        }

        //Home page - List all actions and all Folders in the system
        public ViewResult Index()
        {
            _logger.LogInformation("Log message in the Index() method");
            IEnumerable<Folder> model = _folderRepository.GetAllFolders();
            return View(model);
        }

        //Create Folder GET Action
        [HttpGet]
        public ViewResult Create()
        {
            _logger.LogInformation("Log message in the Create() GET method");
            ViewBag.Folders = _folderRepository.GetAllFolders().ToList();
            return View();
        }

        // Create Folder POST Action
        [HttpPost]
        public IActionResult Create(Folder model)
        {
            _logger.LogInformation("Log message in the Create() POST method");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Adding New Folder");
                Folder newFolder = new Folder
                {
                    Name = model.Name,
                    ParentFolderId = model.ParentFolderId,
                };

                _folderRepository.Add(newFolder);
                _logger.LogInformation("New Folder Added");
                return RedirectToAction("index");
            }
            ViewBag.Folders = _folderRepository.GetAllFolders().ToList();
            return View();
        }
                     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
