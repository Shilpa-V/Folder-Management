using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManagement.Models
{
    public interface ITestCaseRepository
    {
        IEnumerable<TestCase> GetAllTestCases(int? Id);
        TestCase Add(TestCase testCase);
        void DeleteConfirm(int Id);
        TestCase GetTestCaseById(int Id);
    }
}
