using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerShop.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public String StreetAddress { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String PostalCode { get; set; }

        public String PhoneNumber { get; set; }

        public Boolean IsAuthorizedCompany { get; set; }
    }
}
