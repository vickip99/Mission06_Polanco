﻿using System.ComponentModel.DataAnnotations;

namespace Mission06_Polanco.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public required string CategoryName { get; set; }


    }
}
