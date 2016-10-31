using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using api.dataaccess.CacheServices;
using api.dataaccess.Dapper;
using api.dataaccess.Infrastructure;
using Dapper;

namespace api.dataaccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ICacheProvider _cacheProvider;
        private IDbConnection _connection;
        public BaseRepository(IConnectionFactory connectionFactory, ICacheProvider cacheProvider)
        {
            _connection = connectionFactory.GetConnection;
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

        public async Task<TEntity> GetItemAsync<TKey>(TKey id)
        {
            IDbTransaction transaction = _connection.BeginTransaction(); 
            int? commandTimeout = 30;
            var currenttype = typeof(TEntity);
            var idProps = DapperHelper.GetIdProperties(currenttype).ToList();
            
            if (!idProps.Any())
                throw new ArgumentException("Insert<T> only supports an entity with a [Key] or Id property");
            if (idProps.Count() > 1)
                throw new ArgumentException("Insert<T> only supports an entity with a single [Key] or Id property");


            var entityKey = idProps.First();
            var tableName = DapperHelper.GetTableName(currenttype);
            var sb = new StringBuilder();
            sb.Append("Select ");
            DapperHelper.BuildSelect(sb, DapperHelper.GetAllProperties((TEntity)Activator.CreateInstance(typeof(TEntity))).ToArray());
            sb.AppendFormat(" from {0}", tableName);
            sb.Append(" where " + DapperHelper.GetColumnName(entityKey) + " = @Id");
            var dynParms = new DynamicParameters();
            dynParms.Add("@id", id);

            var query = await _connection.QueryAsync<TEntity>(sb.ToString(), dynParms, transaction, commandTimeout);
            return query.FirstOrDefault();
        }



        public async Task<TEntity> AddAsync(TEntity item)
        {
            IDbTransaction transaction = _connection.BeginTransaction(); 
            int? commandTimeout = 30;
            var idProps = DapperHelper.GetIdProperties(item.GetType()).ToList();

            if (!idProps.Any())
                throw new ArgumentException("Insert<T> only supports an entity with a [Key] or Id property");
            if (idProps.Count() > 1)
                throw new ArgumentException("Insert<T> only supports an entity with a single [Key] or Id property");


            var guidvalue = (Guid)idProps.First().GetValue(item, null);
            if (guidvalue == Guid.Empty)
            {
                var newguid = DapperHelper.SequentialGuid();
                idProps.First().SetValue(item, newguid, null);
            }


            var name = DapperHelper.GetTableName(item.GetType());
            var sb = new StringBuilder();
            sb.AppendFormat($"insert into {name}");
            sb.Append(" (");
            DapperHelper.BuildInsertParameters(item, sb);
            sb.Append(") ");
            sb.Append("values");
            sb.Append(" (");
            DapperHelper.BuildInsertValues(item, sb);
            sb.Append(")");

            await _connection.ExecuteAsync(sb.ToString(), item, transaction, commandTimeout);

            return item;
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
