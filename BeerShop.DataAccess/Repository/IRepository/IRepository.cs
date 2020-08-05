﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BeerShop.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);

        IEnumerable<T> GetAll(

            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
            string IncludePoreperties = null
            );

        T GetFirstOrDefault(

            Expression<Func<T, bool>> filter = null,            
            string IncludePoreperties = null
            );

        void Add(T entity); 

        void Remove(int id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
    }
}
