using FolderManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace FolderManager.Test.TestCaseService
{
    class TestcaseServiceFake : ITestCaseRepository
    {

        private readonly List<TestCase> _testcase;
        static int nextId;
        public TestcaseServiceFake()
        {
            _testcase = new List<TestCase>()
            {
                new TestCase()
                {

                    TestCaseId = Interlocked.Increment(ref nextId),
                    Name = "Test1",
                    TestCaseType = TestCaseType.API,
                    StepCount = 1,
                    FolderId = null,
                    
                },
                 new TestCase()
                {
                    TestCaseId = Interlocked.Increment(ref nextId),
                    Name = "Test2",
                    TestCaseType = TestCaseType.External,
                    StepCount = 3,
                    FolderId = 1,

                },
                  new TestCase()
                {
                    TestCaseId = Interlocked.Increment(ref nextId),
                    Name = "Test3",
                    TestCaseType = TestCaseType.Voice,
                    StepCount = 5,
                    FolderId = null,

                },
                   

            };
        }

        public TestCase Add(TestCase testCase)
        {
            testCase.TestCaseId = Interlocked.Increment(ref nextId);
            _testcase.Add(testCase);
            return testCase;
        }

        public void DeleteConfirm(int Id)
        {
            TestCase testCase = _testcase.Find(t => t.TestCaseId == Id);
            _testcase.Remove(testCase);            
        }

        public IEnumerable<TestCase> GetAllTestCases(int? Id)
        {

            if (Id != null)
                return _testcase.Where(t => t.FolderId == Id);
            else
                return _testcase;
        }

        public TestCase GetTestCaseById(int Id)
        {
            return _testcase.FirstOrDefault(t => t.TestCaseId == Id);
        }
    }
}
