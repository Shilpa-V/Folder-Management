using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManagement.Models
{
    public class SQLFolderRepository : IFolderRepository, ITestCaseRepository
    {
        private readonly FolderDbContext context;

        public SQLFolderRepository(FolderDbContext context)
        {
            this.context = context;
        }
        public Folder Add(Folder folder)
        {
            context.Folders.Add(folder);
            context.SaveChanges();
            return folder;
        }

        public TestCase Add(TestCase testCase)
        {
            context.TestCases.Add(testCase);
            context.SaveChanges();
            return testCase;
        }

        public void DeleteConfirm(int Id)
        {
            TestCase deleteTestCase = new TestCase() { TestCaseId = Id };
            context.Entry(deleteTestCase).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return context.Folders;
        }

        public IEnumerable<TestCase> GetAllTestCases(int ? Id)
        {
            if (Id != null)
                return context.TestCases.Where(t => t.FolderId == Id);
            else
                return context.TestCases;
        }

        public TestCase GetTestCaseById(int Id)
        {
            return context.TestCases.FirstOrDefault(t => t.TestCaseId == Id);
        }

        //public List<Folder> GetFolderList()
        //{
        //    return context.Folders.ToList();
        //}
    }
}
