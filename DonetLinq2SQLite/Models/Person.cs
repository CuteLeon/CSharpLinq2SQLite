using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DonetLinq2SQLite.Models
{
    public class Person
    {
        /* 使用 [Key] 声明此字段为主键 */
        [Key]
        [Required]
        [DisplayName("乘客ID")]
        public int ID { get; set; }

        /* 使用 DataType 声明数据类型为 Text */
        [Required]
        [DisplayName("乘客姓名"),DataType(DataType.Text)]
        public string Name { get; set; }

        /* 使用 DataType 声明数据类型为 PhoneNumber */
        [Required]
        [DisplayName("手机号码"), DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        /* 使用 DataType 声明数据类型为 Password */
        [Required]
        [DisplayName("密码"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
