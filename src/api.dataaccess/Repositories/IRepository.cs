using System.Collections.Generic;

namespace api.dataaccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetItem(int id);
        TEntity Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(int id);


    }
}