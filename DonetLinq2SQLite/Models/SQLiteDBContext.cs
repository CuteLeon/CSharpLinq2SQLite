using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DonetLinq2SQLite.Models
{
    public class SQLiteDBContext : DbContext
    {
        /// <summary>
        /// 车辆表
        /// </summary>
        public DbSet<Bus> BusSet { get; set; }

        /// <summary>
        /// 乘客表
        /// </summary>
        public DbSet<Person> PersonSet { get; set; }

        /// <summary>
        /// 使用 App.config 记录的配置连接数据库
        /// </summary>
        public SQLiteDBContext() : base("DotNetSQLiteDB") {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //必须的代码
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(SQLiteDBContext).Assembly);

            //初始化数据种子，用于CodeFirst模式自动创建或修改数据库
            Database.SetInitializer(new SampleData(modelBuilder));
        }
    }
}