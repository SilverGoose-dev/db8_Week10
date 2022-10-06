using Microsoft.AspNetCore.Mvc;
using GroceryCrudDemo.Models;

namespace GroceryCrudDemo.Controllers
{
    public class ProductController : Controller
    {

        //List all Products
        public IActionResult Index()
        {
            List<Product> prods = DAL.GetAllProducts();
            return View(prods);
        }

        // Display detail for single product
        public IActionResult Detail(int id)
        {
            return View(DAL.GetOneProduct(id));
        }

        // Create a product - 2 routes. 
        // Send form to browser
        // Route the browser calls when the form is submitted

        public IActionResult AddForm()
        {
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult Add(Product prod)
        {
            // Validation: If a field is blank, set a message for it
            // and send them back to the form
            // Always validate on both sides --
            //      1. The browser (client) side
            //      2. The server side
            bool isValid = true;
            if (prod.name == null)
            {
                ViewBag.NameMessage = "Name is required.";
                isValid = false;
            }
            if (prod.description == null)
            {
                ViewBag.DescMessage = "Description is required.";
                isValid = false;
            }
            if (prod.price <= 0)
            {
                ViewBag.PriceMessage = "Price must be greater than 0.";
                isValid = false;
            }
            if (isValid)
            {
                DAL.InsertProdcut(prod);
                return Redirect("/product");
            }
            else
            {
                List<Category> cats = DAL.GetAllCategories();
                ViewBag.Name = prod.name;
                ViewBag.Description = prod.description;
                ViewBag.Price = prod.price;
                ViewBag.Inventory = prod.inventory;
                return View("AddForm", cats);
            }

            
        }
        // Delete a product
        // This will not return a view. This will redirect back to index/product
        public IActionResult Delete(int id)
        {
            DAL.DeleteProduct(id);
            return Redirect("/product");
        }

        // Edit a product 
        // Route to send the form prepopualated to the browser
        // Route that does the update and redirects to index

        public IActionResult EditForm(int id)
        {
            ViewData["categories"] = DAL.GetAllCategories();
            return View(DAL.GetOneProduct(id));
        }

        public IActionResult SaveChanges(Product prod)
        {
            DAL.UpdateProduct(prod);
            return Redirect("/product");
        }
    } 
    
    
    
    
}
