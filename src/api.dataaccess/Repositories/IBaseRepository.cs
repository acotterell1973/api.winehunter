using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.dataaccess.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AsQueryable();
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity GetItem(int id);
        TEntity Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(int id);

        Task<bool> ClearAllCachedItems();
        
    }
}