using Microsoft.AspNetCore.Mvc;
using Lab_10._1_BookClub.Models;
namespace Lab_10._1_BookClub.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            List<Person> pers = DAL.GetAllPeople();
            return View(pers);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult AddPerson(Person per)
        {
            bool isValid = true;
            if(per.firstname == null)
            {
                ViewBag.FNameMessage = "A first name is required.";
                isValid = false;
            }
            if (per.lastname == null)
            {
                ViewBag.LNameMessage = "A last name is required.";
                isValid=false;
            }
            if (per.email == null)
            {
                ViewBag.EmailMessage = "A valid email is required.";
                isValid = false;
            }
            if (isValid)
            {
                DAL.InsertPerson(per);
                return Redirect("/person");
            }
            else
            {
                List<Person> pers = DAL.GetAllPeople();
                //ViewBag.Firstname = per.firstname;
                //ViewBag.Lastname = per.lastname;
                //ViewBag.Email = per.email;
                return View("AddForm");
            }
        }
        public IActionResult DeletePerson(int id)
        {
            DAL.DeletePerson(id);
            return Redirect("/person");
        }

        public IActionResult Detail(int id)
        {
            Person per = DAL.GetOnePerson(id);
            return View(per);
        }

        public IActionResult EditForm(int id)
        {
            Person per = DAL.GetOnePerson(id);
            return View(per);
        }

        public IActionResult SaveChanges(Person per)
        {
            DAL.UpdatePerson(per);
            return Redirect("/person");
        }
            






    }
}
