
using System.ComponentModel.DataAnnotations;

namespace Mission06_Polanco.Models
{
    public class Collection
    {
        [Key]
        [Required] 
        public int FilmID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }  

    }
}
