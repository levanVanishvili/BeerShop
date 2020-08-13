using BeerShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerShop.DataAccess.Repository.IRepository
{
    public interface IContainerTypeRepository : IRepository<ContainerType>
    {
        void Update(ContainerType containerType);
    }
}
