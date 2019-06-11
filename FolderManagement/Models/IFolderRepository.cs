using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManagement.Models
{
    public interface IFolderRepository
    {
        Folder Add(Folder folder);
        IEnumerable<Folder> GetAllFolders();
    }
}
