using Microsoft.EntityFrameworkCore;
using posBackend.EF.Const;
using posBackend.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Add(TEntity entitny)
        {
            await _context.Set<TEntity>().AddAsync(entitny);
            return entitny;
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            return entities;
        }

        public  void Delete(TEntity entitny)
        {
            _context.Set<TEntity>().Remove(entitny);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByID(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetListByCondition(Expression<Func<TEntity, bool>> criteria)
        {
            return await _context.Set<TEntity>().Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> criteria, int skip = 0, int take = 10,
            Expression<Func<TEntity, bool>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(criteria).Skip(skip).Take(take);             

            if(orderBy != null)
            {                
                if (orderByDirection == OrderBy.Ascending) 
                    query.OrderBy(orderBy);
                else 
                    query.OrderByDescending(orderBy);
            }
            return await query.ToListAsync();            
        }

        

        //public task<ienumerable<tentity>> search(expression<func<tentity, bool>> criteria, int? skip, int? take, expression<func<tentity, bool>> orderby = null, string orderbydirection = "asc")
        //{
        //    throw new notimplementedexception();
        //}

        public  TEntity Update(TEntity entitny)
        {
            _context.Update(entitny);
            return entitny;
        }
    }
}
