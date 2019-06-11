using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FolderManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FolderManagement.Controllers
{
    // Controller to manage Testcase related Actions
    public class TestCaseController : Controller
    {
        private readonly ITestCaseRepository _testCaseRepository;
        private readonly IFolderRepository _folderRepository;
        private readonly ILogger<TestCaseController> _logger;

        public TestCaseController(ITestCaseRepository testCaseRepository, IFolderRepository folderRepository, ILogger<TestCaseController> logger)
        {
            _testCaseRepository = testCaseRepository;
            _folderRepository = folderRepository;
            _logger = logger;
        }

        // Show All Testcases related to specific folder
        public IActionResult Show(int Id)
        {
            IEnumerable<TestCase> testCases = _testCaseRepository.GetAllTestCases(Id);
            _logger.LogInformation("Getting item {ID}", Id);
            if (testCases == null)
            {
                _logger.LogWarning("Show({Id}) NOT FOUND", Id);
                Response.StatusCode = 404;
                return View("TestcaseNotFound", Id);
            }
                       
            return View(testCases);
        }

        //Create Testcase GET Action
        [HttpGet]
        public ViewResult Create()
        {
            _logger.LogInformation("Log message in the Create() method");
            ViewBag.Folders = _folderRepository.GetAllFolders();
            return View();
        }

        //Create Testcase POST Action
        [HttpPost]
        public IActionResult Create(TestCase model)
        {
            _logger.LogInformation("Log message in the Create() POST method");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Adding New TestCase");
                TestCase newTestCase = new TestCase
                {
                    Name = model.Name,
                    TestCaseType = model.TestCaseType,
                    StepCount = model.StepCount,
                    FolderId = model.FolderId,
                };

                _testCaseRepository.Add(newTestCase);
                _logger.LogInformation("Added New TestCase");
                return RedirectToAction("Index","Home");
            }
            ViewBag.Folders = _folderRepository.GetAllFolders().ToList();
            return RedirectToAction("create");
        }

        //Remove TestCase GET Action
        [HttpGet]
        public ViewResult Delete()
        {
            var model = _testCaseRepository.GetAllTestCases(null);
            return View(model);
        }

        //Remove Testcase after confirmation
        public ActionResult ConfirmDelete(int Id)
        {
            TestCase testCase = _testCaseRepository.GetTestCaseById(Id);
            _logger.LogInformation("Log message in the Delete() method");
            if (testCase == null)
                return NotFound();

            _testCaseRepository.DeleteConfirm(Id);
            _logger.LogInformation("Testcase Deleted");
            return RedirectToAction("Index", "Home");
        }
    }
}