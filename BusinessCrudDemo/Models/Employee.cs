using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;


namespace BusinessCrudDemo.Models
{
    [Table ("employee")]
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

    }
}
