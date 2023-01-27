using posBackend.EF.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Repositories
{
    public interface IRepository<TEntitny> where TEntitny : class 
    {
        Task<IEnumerable<TEntitny>> GetAll();
        Task<TEntitny> GetByID(int id);
        Task<IEnumerable<TEntitny>> GetListByCondition(Expression<Func<TEntitny, bool>> criteria);
        Task<IEnumerable<TEntitny>> Search(Expression<Func<TEntitny, bool>> criteria, int skip = 0, int take = 10,
            Expression<Func<TEntitny, bool>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        //Task<IEnumerable<TEntitny>> Search(string search, int skip = 0, int take = 10,
        //    Expression<Func<TEntitny, bool>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        Task<TEntitny> Add(TEntitny entitny);
        Task<IEnumerable<TEntitny>> AddRange(IEnumerable<TEntitny> entities);
        TEntitny Update(TEntitny entitny);
        void Delete(TEntitny entitny);
        void DeleteRange(IEnumerable<TEntitny> entities);

    }
}
