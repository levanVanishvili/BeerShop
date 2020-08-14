using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeerShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String Description { get; set; }

        [Required]
        public String ABV { get; set; }

        [Required]
        public String Brewery { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }

        public int ImageUrl { get; set; }

        [Required]
        public int StyleId{ get; set; }

        [ForeignKey("StyleId")]
        public Style Style { get; set; }

        [Required]
        public int ContainerTypeId { get; set; }

        [ForeignKey("ContainerTypeId")]
        public ContainerType ContainerType { get; set; }

    }
}
