using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;


namespace BusinessCrudDemo.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=business;Uid=root;Pwd=abc123;");

        //Read all

        public static List<Employee> GetAllEmployees()
        {
            return DB.GetAll<Employee>().ToList();
        }

        // Read one

        public static Employee GetOneEmployee(int id)
        {
            return DB.Get<Employee>(id);
        }

        // Create one 

        public static Employee AddEmployee(Employee emp)
        {
            DB.Insert(emp);
            return emp;
        }

        // Delete one
        
        public static void DeleteEmployee(int id)
        {
            Employee emp = new Employee();
            emp.ID = id;
            DB.Delete(emp);
        }
        // Update One
        public static void UpdateEmployee(Employee emp)
        {
            DB.Update<Employee>(emp);
        }

    }
}
