using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManagement.Models
{
    public class SQLFolderRepository : IFolderRepository
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

        public IEnumerable<Folder> GetAllFolders()
        {
            return context.Folders;
        }

        public IEnumerable<TestCase> GetAllTestCases(int Id)
        {
            return context.TestCases.Where(t => t.Folder.FolderId == Id);
        }
    }
}
