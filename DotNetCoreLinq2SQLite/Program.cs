using System;
using System.Collections.Generic;
using DotNetCoreLinq2SQLite.Models;

namespace DotNetCoreLinq2SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreSQLiteDBContext DBContext = new CoreSQLiteDBContext();
            DBContext.SaveChanges();
            Console.WriteLine("Hello World!");
        }
    }
}
