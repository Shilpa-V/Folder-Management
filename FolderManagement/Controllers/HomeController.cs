using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FolderManagement.Models;

namespace FolderManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFolderRepository _folderRepository;

        public HomeController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        public ViewResult Index()
        {
            var model = _folderRepository.GetAllFolders();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Folder model)
        {
            if (ModelState.IsValid)
            {
                Folder newFolder = new Folder
                {
                    Name = model.Name,
                    ParentFolderId = model.ParentFolderId,
                };

                _folderRepository.Add(newFolder);
                return RedirectToAction("index");
            }
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
