using BeerShop.DataAccess.Data;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerShop.DataAccess.Repository
{
    class ContainerTypeRepository : Repository<ContainerType> , IContainerTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public ContainerTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ContainerType ContainerType)
        {
            var objFromDb = _db.ContainerTypes.FirstOrDefault(c => c.Id == ContainerType.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = ContainerType.Name;
                objFromDb.Size = ContainerType.Size;
            }
            

        }
    }
}
