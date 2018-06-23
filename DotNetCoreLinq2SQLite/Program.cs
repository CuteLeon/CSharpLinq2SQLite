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
            using (SampleDBContext BlogDBContext = new SampleDBContext())
            {
                BlogDBContext.Set<Publisher>().Add(new Publisher()
                {
                    Name = "测试发布者",
                    Blogs = new List<Blog>() {
                        new Blog() { Content="测试博客 A"},
                        new Blog() { Content="测试博客 B"},
                        new Blog() { Content="测试博客 C"},
                    }
                });
                /* 存在外键约束，博客的PublisherID必须为数据库内当前已经存在的值，
                 * 需要先保存发布者信息至数据库，否则下面空降博客会导致外键约束失败。
                 */
                BlogDBContext.SaveChanges();
                BlogDBContext.Blogs.Add(
                    new Blog()
                    {
                        Content = "空降一篇博客",
                        PublisherID = BlogDBContext.Publishers.First(Publisher => Publisher.Name == "测试发布者").PublisherID
                    });
                /* 存在外键约束，博客的PublisherID必须为数据库内当前已经存在的值，
                 * 下面使用 PublisherID=10101 发布博客将会失败。
                 */
                //BlogDBContext.Blogs.Add(new Blog() { Content = "幽灵博客", PublisherID=10101});
                BlogDBContext.SaveChanges();

                Console.WriteLine("《测试博客 B》 的发布者为 : " + BlogDBContext.Blogs.First(Blog => Blog.Content == "测试博客 B").Publisher.Name);
                Console.WriteLine($"测试发布者 发布了 {BlogDBContext.Publishers.First(Publisher => Publisher.Name == "测试发布者").Blogs.Count} 篇博客。");
                Console.WriteLine("Blogs.Count : " + BlogDBContext.Blogs.Count().ToString());
                Console.WriteLine("Publishers.Count : " + BlogDBContext.Publishers.Count().ToString());
            }

            Console.Read();
        }
    }
}
