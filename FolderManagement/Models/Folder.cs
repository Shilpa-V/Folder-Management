using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManagement.Models
{
    public class Folder
    {
        [Required]
        public int FolderId { get; set; }

        public int ? ParentFolderId { get; set; }

        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Required]
        public string Name { get; set; }

        public ICollection<TestCase> TestCases { get; set; }
    }
}
