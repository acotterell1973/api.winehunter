using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.dataaccess.CacheServices;
using api.dataaccess.Infrastructure;

namespace api.dataaccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ICacheProvider _cacheProvider;

        public BaseRepository(IConnectionFactory connectionFactory, ICacheProvider cacheProvider)
        {
            _connectionFactory = connectionFactory;
            _cacheProvider = cacheProvider;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity item)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearAllCachedItems()
        {
            return await _cacheProvider.InvalidateAll();
        }
    }
}
