using Dapper;
using Dapper.Contrib.Extensions;
namespace Lab_10._1_BookClub.Models
{
    [Table("presentation")]
    public class Presentation
    {
        [Key]
        public int ID { get; set; }
        public int personid { get; set; }
        public DateTime presentationdate { get; set; }
        public string booktitle { get; set; }
        public string bookauthor { get; set; }
        public string genre { get; set; }
    }
}
