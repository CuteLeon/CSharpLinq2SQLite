using DonetLinq2SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonetLinq2SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteDBContext DBContext = new SQLiteDBContext();

            Console.WriteLine("有两个乘客的BUS : " + 
                DBContext.BusSet.FirstOrDefault(b => b.Persons.Count == 2).Name);

            Console.WriteLine("——————\n输出车辆信息：");
            foreach (Bus b in DBContext.BusSet.ToArray())
            {
                Console.WriteLine(string.Format(
                    "Bus ID : {0}\nName : {1}\nPersons : {2}\n***************",
                    b?.ID,
                    b?.Name,
                    (b?.Persons?.Count.ToString()) ?? "获取失败"
                ));
            }

            Console.WriteLine("——————\n输出乘客信息：");
            foreach (Person p in DBContext.PersonSet.ToArray())
            {
                Console.WriteLine(string.Format(
                    "Person ID : {0}\nName : {1}\nTelephone:{2}\n***************",
                    p.ID,
                    p.Name,
                    p.Telephone
                ));
            }

            Console.WriteLine("——————\n上车：");
            //直接向bus增加person
            Bus bus = DBContext.BusSet.First(b => b.ID == 2);
            bus.Persons.Add(new Person() { Name = "新上车乘客", Password = "p@ssword", Telephone = "+86-12345678910" });
            //先储存person，再加入bus
            Person person = new Person() { Name = "另一个新上车乘客", Password = "Ap@ssword", Telephone = "+86-12345678911" };
            DBContext.PersonSet.Add(person);
            bus.Persons.Add(person);
            //储存更改
            DBContext.SaveChanges();

            Console.WriteLine("——————\n输出车上乘客信息：");
            foreach (Person p in DBContext.BusSet.First(b => b.ID == 2).Persons)
            {
                Console.WriteLine(string.Format(
                    "Person ID : {0}\nName : {1}\nTelephone:{2}\n***************",
                    p.ID,
                    p.Name,
                    p.Telephone
                ));
            }
            
            Console.WriteLine("——————\n下车：");
            bus.Persons.RemoveAt(0);
            bus.Persons.RemoveAt(2);
            bus.Persons.Last().Name = "最后一个上车乘客";
            DBContext.SaveChanges();

            Console.WriteLine("——————\n输出车上乘客信息：");
            foreach (Person p in DBContext.BusSet.First(b => b.ID == 2).Persons)
            {
                Console.WriteLine(string.Format(
                    "Person ID : {0}\nName : {1}\nTelephone:{2}\n***************",
                    p.ID,
                    p.Name,
                    p.Telephone
                ));
            }

            Console.Read();
        }
    }
}
