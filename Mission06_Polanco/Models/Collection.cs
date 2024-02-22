
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Polanco.Models
{
    public class Collection
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")] //by default is required
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 1000000)]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is required.")]
        public int Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Copied To Plex is required.")]
        public int CopiedToPlex { get; set; }

        public string? Notes { get; set; }  

    }
}
