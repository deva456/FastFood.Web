using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Services.Models
{
    public class CreateCategoryDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
