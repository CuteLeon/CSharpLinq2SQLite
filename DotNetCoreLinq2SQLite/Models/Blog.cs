using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreLinq2SQLite.Models
{
    public class Blog
    {
        [Key,Required]
        public int BlogID { get; set; }
        [Required]
        public string Content { get; set; }
        
        //用于约束发布者ID外键
        [Required]
        public int PublisherID { get; set; }
        //生命上述 PublisherID 变量为此值的约束条件
        [ForeignKey("PublisherID")]
        public virtual Publisher Publisher { get; set; }

    }
}
