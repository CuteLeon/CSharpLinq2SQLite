using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetCoreLinq2SQLite.Models
{
    public class Publisher
    {
        [Key,Required]
        [DisplayName("发布者ID")]
        public int PublisherID { get; set; }

        [Required]
        [DisplayName("发布者名称")]
        public string Name { get; set; }

        [DisplayName("博客列表")]
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
