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
               BlogDBContext.SaveChanges();

                /* 存在外键约束，博客的PublisherID必须为数据库内当前已经存在的值，
                    需要先保存发布者信息至数据库，否则空降博客会导致外键约束失败 */
               BlogDBContext.Blogs.Add(
                   new Blog()
                   {
                       Content = "空降一篇博客",
                       PublisherID = BlogDBContext.Publishers.First(Publisher => Publisher.Name == "测试发布者").PublisherID
                   });

                /* 存在外键约束，博客的PublisherID必须为数据库内当前已经存在的值，
                    下面使用 PublisherID=10101 发布博客将会失败 */
                //BlogDBContext.Blogs.Add(new Blog() { Content = "幽灵博客", PublisherID=10101});
                BlogDBContext.SaveChanges();

                Console.WriteLine("《测试博客 B》 的发布者为 : " + BlogDBContext.Blogs.First(Blog => Blog.Content == "测试博客 B").Publisher.Name);
                //TODO: 遗留问题-1：通过种子数据添加的 BlogDBContext.Publishers.First(Publisher => Publisher.Name == "测试发布者").Blogs.Count 会输出 1 (应为4)
                Console.WriteLine($"测试发布者 发布了 {BlogDBContext.Blogs.Where(blog => blog.PublisherID == BlogDBContext.Publishers.FirstOrDefault(publisher => publisher.Name == "测试发布者").PublisherID).Count()} 篇博客。");

                Console.WriteLine(string.Empty);
                Console.WriteLine("Blogs.Count : " + BlogDBContext.Blogs.Count().ToString());
                Console.WriteLine("Blogs :");
                //TODO: 遗留问题-2：通过种子数据添加的{blog.Publisher?.Name ?? "*"} 会输出 * (应为博客发布者名称)
                //Console.WriteLine($"\t{blog.Content} \tvia : {blog.Publisher?.Name ?? "*"}\t(ID : {blog.PublisherID})");
                foreach (Blog blog in BlogDBContext.Blogs)
                    Console.WriteLine($"\t{blog.Content} \tvia : {BlogDBContext.Publishers.First(publisher => publisher.PublisherID == blog.PublisherID).Name}\t(ID : {blog.PublisherID})");

                Console.WriteLine(string.Empty);
                Console.WriteLine("Publishers.Count : " + BlogDBContext.Publishers.Count().ToString());
                Console.WriteLine("Publishers :");
                foreach (Publisher publisher in BlogDBContext.Publishers)
                    Console.WriteLine($"\t{publisher.Name} \t(ID : {publisher.PublisherID})");
            }

            Console.Read();
        }
    }
}
