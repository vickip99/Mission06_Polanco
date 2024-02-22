using System.ComponentModel.DataAnnotations;

//creating a class that will be how it is in the database so we can attach Movies table with Categories (FK) 
namespace Mission06_Polanco.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }


    }
}
