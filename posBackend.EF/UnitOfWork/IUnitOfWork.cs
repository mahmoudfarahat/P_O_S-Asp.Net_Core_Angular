using posBackend.EF.Models;
using posBackend.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Unit> Units { get; }
        IRepository<Product> Products { get; }
        IRepository<ProductUnit> ProductUnits { get; }
        IRepository<Customer> Customers { get; }

        int Complete();

    }
}
