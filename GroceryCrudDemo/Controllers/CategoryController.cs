using Microsoft.AspNetCore.Mvc;
using GroceryCrudDemo.Models;


namespace GroceryCrudDemo.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Category cat)
        {
            DAL.InsertCategory(cat);
            return Redirect("/category");
        }

        // For detail page, we have to decide how to write our code. 
        // We have some choices for the URL:
        // We could listen for a url like this:
        //          https://localhost:7227/category/detail/FRUIT
        // and get the ID from the last "folder"
        // or we could listen for a url like this:
        //          https://localhost:7227/category/detail?id-FRUIT
        // where we get the ID from the query parameters
        // For the query one, we just wrote code like this
        // public IAcctionResult Detail(string id)
        
        public IActionResult Detail(string id)
        {
            Category cat = DAL.GetOneCategory(id);
            return View(cat);
        }

        public IActionResult ConfirmDelete(string id)
        {
            Category cat = DAL.GetOneCategory(id);
            //ViewData["categoryid"] = id;
            return View(cat);
        }

        public IActionResult Delete(string id)
        {
            DAL.DeleteCategory(id);
            return Redirect("/category");
        }

        public IActionResult EditForm(string id)
        {
            Category cat = DAL.GetOneCategory(id);
            return View(cat);
        }

        public IActionResult SaveChanges(Category cat)
        {
            DAL.UpdateCategory(cat);
            return Redirect("/category");
        }
    }
}
