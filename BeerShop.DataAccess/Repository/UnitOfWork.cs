using BeerShop.DataAccess.Data;
using BeerShop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BeerShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Style = new StyleRepository(_db);
            ContainerType = new ContainerTypeRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public IStyleRepository Style { get; private set; }
        public IContainerTypeRepository ContainerType { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
