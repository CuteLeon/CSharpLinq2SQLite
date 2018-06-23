using System.ComponentModel.DataAnnotations;

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
    }
}
