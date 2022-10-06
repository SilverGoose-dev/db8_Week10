using Microsoft.AspNetCore.Mvc;
using Lab_10._1_BookClub.Models;

namespace Lab_10._1_BookClub.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            //Person persons = DAL.GetAllPeople();
            //ViewBag.Firstname = persons.firstname;
            List<Presentation> pres = DAL.GetAllPresentations();
            return View(pres);
        }

        public IActionResult AddForm()
        {
            List<Person> persons = DAL.GetAllPeople();
            return View(persons);
        }

        public IActionResult Add(Presentation pres)
        {
            bool isValid = true;
            
            if (pres.booktitle == null)
            {
                ViewBag.BookMessage = "Book title is required.";
                isValid = false;
            }
            if (pres.bookauthor == null)
            {
                ViewBag.AuthorMessage = "Author is required";
                isValid = false;
            }
            if (pres.genre == null)
            {
                ViewBag.GenreMessage = "Genre is required";
                isValid = false;
            }
            if (isValid)
            {
                DAL.InsertPresentation(pres);
                return Redirect("/presentation");
            }
            else
            {
                List<Person> pers = DAL.GetAllPeople();
                return View("AddForm", pers);
            }
        }

        public IActionResult Detail(int id)
        {
            
            return View(DAL.GetOnePresentation(id));
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePresentation(id);
            return Redirect("/presentation");
        }
         
        public IActionResult EditForm(int id)
        {
            Presentation pers = DAL.GetOnePresentation(id);
            return View(pers);
        }

        public IActionResult SaveChanges(Presentation pres)
        {
            DAL.UpdatePresentation(pres);
            return Redirect("/presentation");
        }



    }
}
