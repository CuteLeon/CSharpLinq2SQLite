using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreLinq2SQLite.Models
{
    public class Blog
    {
        [Key,Required]
        [DisplayName("博客ID")]
        public int BlogID { get; set; }

        [Required]
        [DisplayName("博客内容")]
        public string Content { get; set; }
        
        //用于约束发布者ID外键
        [Required]
        [DisplayName("发布者ID")]
        public int PublisherID { get; set; }

        //声明上述 PublisherID 变量为此值的约束条件
        [ForeignKey("PublisherID")]
        [DisplayName("发布者")]
        public virtual Publisher Publisher { get; set; }

    }
}
