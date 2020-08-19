using BeerShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerShop.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        //void Update(ApplicationUser applicationUser);
    }
}
