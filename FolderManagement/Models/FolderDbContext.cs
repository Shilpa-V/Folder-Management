using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManagement.Models
{
    public class FolderDbContext : DbContext
    {
        public FolderDbContext(DbContextOptions<FolderDbContext> options)
            :base (options)
        {

        }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<TestCase> TestCases { get; set; }

    }
}
