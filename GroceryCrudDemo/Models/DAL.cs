﻿using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace GroceryCrudDemo.Models
{


    // Functionality to access our data.
    // This is the "data access layer"
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=grocerystore;Uid=root;Pwd=abc123;");

        // CRUD operations for our Category table 

        // Read all

        public static List<Category> GetAllCategories()
        {
            // Throughout our app, any time we need to get a list of all categories, we just call DAL.GetAllCategories();
            return DB.GetAll<Category>().ToList(); //gets all the rows in the database
        }

        // Read one

        public static Category GetOneCategory(string id)
        {
            return DB.Get<Category>(id);
        }

        // Create one (insert)

        public static Category InsertCategory(Category cat)
        {
            DB.Insert<Category>(cat);
            return cat;
        }

        // Delete one

        public static void DeleteCategory(string id)
        {

            // Delete all products in this category (Make sure user understands what they are doing)
            // Use dapper's tool to prevent SQL injection attacks
            // We're building an anonymous object that looks like this:
            // {
            //      catid="FRUIT"
            // }
            // Dapper will then find #catid and replace it with 'FRUIT'
            // to build the SQL string 
            // example:
            //      delete from product where category=@catid
            //      delete from product where category='FRUIT
            DB.Execute($"delete from product where category='@catid'", new {catid=id});
            Category cat = new Category();
            cat.id = id;
            DB.Delete<Category>(cat);
        }

        // Update one (edit)

        public static void UpdateCategory(Category cat)
        {
            DB.Update<Category>(cat);
        }



        // CRUD operations for out Product table 

        // Read all
        public static List<Product> GetAllProducts()
        {
            return DB.GetAll<Product>().ToList();
        }

        // Read one
        public static Product GetOneProduct(int id)
        {
            return DB.Get<Product>(id);
        }

        // Create one (insert)
        public static Product InsertProdcut(Product prod)
        {
            DB.Insert(prod);   // The insert function takes an instance of Product, so the insert functions kn ow what class and table to use. 
            return prod;
        }


        // Delete one
        public static void DeleteProduct(int id)
        {
            Product prod = new Product();
            prod.id = id;
            DB.Delete(prod);
        }
        // Update one (edit)
        public static void UpdateProduct(Product prod)
        {
            DB.Update(prod);
        }

    }
}
