using FolderManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FolderManager.Test
{
    class FolderServiceFake : IFolderRepository
    {
        private readonly List<FolderManagement.Models.Folder> _folders;
        static int nextId;
        public FolderServiceFake()
        {
            _folders = new List<FolderManagement.Models.Folder>()
            {
                new FolderManagement.Models.Folder()
                {
                    FolderId = Interlocked.Increment(ref nextId),
                    ParentFolderId = null,
                    Name = "Main1"
                },
                 new FolderManagement.Models.Folder()
                {
                    FolderId = Interlocked.Increment(ref nextId),
                    ParentFolderId = null ,
                    Name = "Main2"
                },
                  new FolderManagement.Models.Folder()
                {
                    FolderId = Interlocked.Increment(ref nextId),
                    ParentFolderId = 1,
                    Name = "Sub1.1"
                },
                   new FolderManagement.Models.Folder()
                {
                    FolderId = Interlocked.Increment(ref nextId),
                    ParentFolderId = 1,
                    Name = "Sub1.2"
                },
                    new FolderManagement.Models.Folder()
                {
                     FolderId = Interlocked.Increment(ref nextId),
                     ParentFolderId = 2,
                     Name = "Sub2.1"
                },

            };
        }


        public FolderManagement.Models.Folder Add(FolderManagement.Models.Folder folder)
        {
            //Guid guid = Guid.NewGuid();
            //Random random = new Random();
            //folder.FolderId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
            folder.FolderId = Interlocked.Increment(ref nextId);
            _folders.Add(folder);
            return folder;
        }

        public IEnumerable<FolderManagement.Models.Folder> GetAllFolders()
        {
            return _folders;
        }

    }
}
