using posBackend.EF.Models;
using posBackend.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _Context;
        public IRepository<Category> Categories { get; private set; }
        public IRepository<Unit> Units { get; private set; }
        public IRepository<Product> Products { get; private set; }

        public IRepository<ProductUnit> ProductUnits { get; private set; }

        public IRepository<Customer> Customers { get; private set; }
        public IRepository<Store> Stores { get; private set; }
        public IRepository<OpenBalance> OpenBalances { get; private set; }
        public IRepository<OpenBalanceDt> OpenBalancesDt { get; private set; }



        public UnitOfWork(ApplicationDbContext Context)
        {
            _Context = Context;

            Categories = new Repository<Category>(_Context);
            Units = new Repository<Unit>(_Context);
            Products = new Repository<Product>(_Context);
            ProductUnits = new Repository<ProductUnit>(_Context);
            Customers = new Repository<Customer>(_Context);
            Stores = new Repository<Store>(_Context);
            OpenBalances = new Repository<OpenBalance>(_Context);
            OpenBalancesDt = new Repository<OpenBalanceDt>(_Context);


        }

        public int Complete()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
