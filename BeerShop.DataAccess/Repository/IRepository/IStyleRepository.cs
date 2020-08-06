using BeerShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerShop.DataAccess.Repository.IRepository
{
    public interface IStyleRepository : IRepository<Style>
    {
        void Update(Style style);
    }
}
