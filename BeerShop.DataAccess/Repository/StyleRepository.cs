using BeerShop.DataAccess.Data;
using BeerShop.DataAccess.Repository.IRepository;
using BeerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerShop.DataAccess.Repository
{
    class StyleRepository : Repository<Style> , IStyleRepository
    {
        private readonly ApplicationDbContext _db;

        public StyleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Style style)
        {
            var objFromDb = _db.Styles.FirstOrDefault(s => s.Id == style.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = style.Name;

                _db.SaveChanges();
            }
            

        }
    }
}
