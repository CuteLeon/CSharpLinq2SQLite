using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNetCoreLinq2SQLite.Models
{
    public class CoreSQLiteDBContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CoreSQLiteDB.db");
        }
    }

}
