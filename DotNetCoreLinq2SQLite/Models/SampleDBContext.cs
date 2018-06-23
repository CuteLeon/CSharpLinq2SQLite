using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreLinq2SQLite.Models
{
    public class SampleDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        private static bool _created = false;
        public SampleDBContext()
        {
            if (!_created)
            {
                _created = true;
                //每次都删除原数据库
                //Database.EnsureDeleted();
                //数据库不存在则创建
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //表不存在时，自动创建数据表
            modelBuilder.Entity<Blog>().ToTable("Blogs");
            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            //TODO: 使用 modelBuilder.Entity<T>().HasData(new T() { /* ... */ }); 添加种子数据
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=CoreSQLiteDB.db");
        }
    }
}
