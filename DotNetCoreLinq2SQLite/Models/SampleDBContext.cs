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
                Database.EnsureDeleted();
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

            //种子数据：(注意 : ID 从1开始)
            modelBuilder.Entity<Publisher>().HasData(new Publisher[] {
                new Publisher(){ PublisherID = 1, Name = "种子发布者-1" },
                new Publisher(){ PublisherID = 2, Name = "种子发布者-2" },
                new Publisher(){ PublisherID = 3, Name = "种子发布者-3" },
            });

            modelBuilder.Entity<Blog>().HasData(new Blog[] {
                new Blog() { BlogID = 1, Content = "种子博客-1", PublisherID = 1 },
                new Blog() { BlogID = 2, Content = "种子博客-2", PublisherID = 1 },
                new Blog() { BlogID = 3, Content = "种子博客-3", PublisherID = 1 },
                new Blog() { BlogID = 4, Content = "种子博客-4", PublisherID = 2 },
                new Blog() { BlogID = 5, Content = "种子博客-5", PublisherID = 3 },
                new Blog() { BlogID = 6, Content = "种子博客-6", PublisherID = 3 },
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=CoreSQLiteDB.db");
        }
    }
}
