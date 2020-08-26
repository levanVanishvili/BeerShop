using BeerShop.DataAccess.Data;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerShop.DataAccess.Repository
{
    class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.Update(obj);
        }
    }
}
