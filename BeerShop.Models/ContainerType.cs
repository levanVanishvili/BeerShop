using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerShop.Models
{
    public class ContainerType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Container Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Container Size")]
        [Required]
        public String Size { get; set; }
    }
}
