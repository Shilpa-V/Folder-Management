using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManagement.Models
{
    public class TestCase
    {
        [Required]
        public int TestCaseId { get; set; }

        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Required]
        public string Name { get; set; }

        [Required]
        public TestCaseType TestCaseType { get; set; }

        [Required]
        public int StepCount { get; set; }

        [ForeignKey("FolderId")]
        public Folder Folder { get; set; }





    }
}
