﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BeerShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IStyleRepository Style { get; }

        IContainerTypeRepository ContainerType { get; }

        IProductRepository Product { get; }

        ICompanyRepository Company { get; }

        IApplicationUserRepository ApplicationUser { get; }

        ISP_Call SP_Call { get; }

        void Save();
    }
}
