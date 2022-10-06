using Microsoft.AspNetCore.Mvc;
using BusinessCrudDemo.Models;

namespace BusinessCrudDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> emp = DAL.GetAllEmployees();
            return View(emp);
        }

        public IActionResult EmployeeDetail(int id)
        {
            Employee emp = DAL.GetOneEmployee(id);
            return View(emp);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult AddEmployee(Employee emp)
        {
            DAL.AddEmployee(emp);
            return Redirect("/employee");
        }

        public IActionResult Delete(int id)
        {
            DAL.DeleteEmployee(id);
            return Redirect("/employee");
        }

        public IActionResult EditForm(int id)
        {
            Employee emp = DAL.GetOneEmployee(id);
            return View(emp);
        }

        public IActionResult SaveChanges(Employee emp)
        {
            DAL.UpdateEmployee(emp);
            return Redirect("/employee");
        }
    }
}
