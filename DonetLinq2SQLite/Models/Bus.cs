using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DonetLinq2SQLite.Models
{
    public class Bus
    {
        /* 使用 [Key] 声明此字段为主键 */
        [Key]
        [Required]
        [DisplayName("车辆ID")]
        public int ID { get; set; }

        /* 使用 DataType 声明数据类型为 Text */
        [Required]
        [DisplayName("车辆名称"),DataType(DataType.Text)]
        public string Name { get; set; }

        /* 使用 virtual 关键字修饰，否则集合将为空 */
        [Required]
        [DisplayName("乘客")]
        public virtual List<Person> Persons { get; set; }
    }
}
