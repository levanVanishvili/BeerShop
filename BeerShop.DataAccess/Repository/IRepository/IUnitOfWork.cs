using System;
using System.Collections.Generic;
using System.Text;

namespace BeerShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IStyleRepository Style { get; }

        ISP_Call SP_Call { get; }

        void Save();
    }
}
