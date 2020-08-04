using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerShop.Models
{
    public class Style
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Style Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
