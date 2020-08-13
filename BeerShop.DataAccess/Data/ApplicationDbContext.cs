using System;
using System.Collections.Generic;
using System.Text;
using BeerShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeerShop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Style> Styles { get; set; }
        public DbSet<ContainerType> ContainerTypes { get; set; }
    }
}
