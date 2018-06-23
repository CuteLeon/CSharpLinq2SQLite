using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetCoreLinq2SQLite.Models
{
    public class Publisher
    {
        [Key,Required]
        public int PublisherID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public virtual List<Blog> Blogs { get; set; }
    }
}
