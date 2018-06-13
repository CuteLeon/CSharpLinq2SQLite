using System.Collections.Generic;
using System.Data.Entity;
using SQLite.CodeFirst;

namespace DonetLinq2SQLite.Models
{
    /* 需要继承 SQLite.CodeFirst 内的 SqliteInitializerBase:IDatabaseInitializer
     * SqliteDropCreateDatabaseAlways : 总是使用初始化数据种子的数据库
     * SqliteDropCreateDatabaseWhenModelChanges : 仅当数据库模型变化时自动更新数据库
     */

    class SampleData : SqliteDropCreateDatabaseAlways<SQLiteDBContext>
    {
        public SampleData(DbModelBuilder modelBuilder)
            : base(modelBuilder) {}

        //覆写此方法，用于初始化数据种子
        protected override void Seed(SQLiteDBContext context)
        {
            //添加数据
            context.BusSet.Add(
                new Bus()
                {
                    Name = "Bus_0",
                    Persons = new List<Person>()
                    {
                        new Person(){
                            Name="Person_0",
                            Password="password_0",
                            Telephone="+86-12345678900"
                        },
                        new Person(){
                            Name="Person_1",
                            Password="password_1",
                            Telephone="+86-12345678901"
                        },
                        new Person(){
                            Name="Person_2",
                            Password="password_2",
                            Telephone="+86-12345678902"
                        },
                    }
                }
            );
            context.BusSet.Add(
                new Bus()
                {
                    Name = "Bus_1",
                    Persons = new List<Person>()
                    {
                        new Person(){
                            Name="Person_3",
                            Password="password_3",
                            Telephone="+86-12345678903"
                        },
                        new Person(){
                            Name="Person_4",
                            Password="password_4",
                            Telephone="+86-12345678904"
                        },
                    }
                }
            );
            context.BusSet.Add(
                new Bus()
                {
                    Name = "Bus_2",
                    Persons = new List<Person>()
                    {
                        new Person(){
                            Name="Person_5",
                            Password="password_5",
                            Telephone="+86-12345678905"
                        },
                    }
                }
            );
            //保存更改
            context.SaveChanges();

            //交还父类
            base.Seed(context);
        }
    }
}
