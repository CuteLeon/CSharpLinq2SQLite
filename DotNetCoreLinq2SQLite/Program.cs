using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCoreLinq2SQLite.Models;

namespace DotNetCoreLinq2SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            //CoreSQLiteDBContext BlogDBContext = new CoreSQLiteDBContext();
            SampleDBContext BlogDBContext = new SampleDBContext();
            //BlogDBContext.Blogs.Add(new Blog() { Content = "幽灵博客" });
            BlogDBContext.Set<Publisher>().Add(new Publisher()
            {
                Name = "测试发布者",
                Blogs = new List<Blog>() {
                    new Blog() { Content="测试博客 A"},
                    new Blog() { Content="测试博客 B"},
                    new Blog() { Content="测试博客 C"},
                }
            });
            //BlogDBContext.Blogs.Add(new Blog() { Content = "空降一篇博客", PublisherID=1});
            BlogDBContext.SaveChanges();
            Console.WriteLine("Blogs.Count : " + BlogDBContext.Blogs.Count().ToString());
            Console.WriteLine("Publishers.Count : " + BlogDBContext.Publishers.Count().ToString());
            Console.Read();
        }
    }
}
