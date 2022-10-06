using Dapper;
using Dapper.Contrib.Extensions;
namespace Lab_10._1_BookClub.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }
}
