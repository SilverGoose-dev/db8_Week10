using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace Lab_10._1_BookClub.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=abc123;");

        public static List<Person> GetAllPeople()
        {
            return DB.GetAll<Person>().ToList();
        }

        public static Person GetOnePerson(int id)
        {
            return DB.Get<Person>(id);
        }

        public static Person InsertPerson(Person per)
        {
            DB.Insert<Person>(per);
            return per;
        }

        public static void DeletePerson(int id)
        {
            Person per = new Person();
            per.ID = id;
            DB.Delete<Person>(per);
        }

        public static void UpdatePerson(Person per)
        {
            DB.Update<Person>(per);
        }



        public static List<Presentation> GetAllPresentations()
        {
            return DB.GetAll<Presentation>().ToList();
        }

        public static Presentation GetOnePresentation(int id)
        {
            return DB.Get<Presentation>(id);
        }

        public static Presentation InsertPresentation(Presentation pres)
        {
            DB.Insert(pres);
            return pres;
        }

        public static void DeletePresentation(int id)
        {
            Presentation pres = new Presentation();
            pres.ID = id;
            DB.Delete(pres);
        }

        public static void UpdatePresentation(Presentation pres)
        {
            DB.Update(pres);
        }


    }

    
}
