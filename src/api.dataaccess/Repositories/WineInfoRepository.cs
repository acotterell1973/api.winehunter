using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using api.dataaccess.CacheServices;
using api.dataaccess.Entities;
using api.dataaccess.Infrastructure;
using Dapper;

namespace api.dataaccess.Repositories
{

    public class WineInfoBaseRepository : BaseRepository<WineInfo> ,IWineInfoRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ICacheProvider _cacheProvider;


        public WineInfoBaseRepository(IConnectionFactory connectionFactory, ICacheProvider cacheProvider ) : base(connectionFactory, cacheProvider)
        {
            _connectionFactory = connectionFactory;
            _cacheProvider = cacheProvider;
        }

        public async Task<WineInfo> FindByUpcAsync(string upc)
        {
            string cacheKey = $"FindByUpcAsync::{upc}";
            var wineInfo = await _cacheProvider.GetAsync(cacheKey, async () =>
            {
                const string query = "GetWineVarieties";
                var param = new DynamicParameters();
                param.Add("@upc", upc);

                return await SqlMapper.QueryFirstAsync<WineInfo>(_connectionFactory.GetConnection,
                    query,
                    param,
                    commandType: CommandType.StoredProcedure);

            }, TimeSpan.FromMinutes(15));
          
            return wineInfo;
        }

        public async Task<List<WineInfo>> FindByProducerAsync(string producer)
        {
            string cacheKey = $"FindByProducerAsync::{producer}";

            var list =  await _cacheProvider.GetAsync(cacheKey, async () =>
            {
                const string query = "GetWineVarieties";
                var param = new DynamicParameters();
                param.Add("@producer", producer);

                return (List<WineInfo>) await SqlMapper.QueryAsync<WineInfo>(_connectionFactory.GetConnection,
                    query,
                    param,
                    commandType: CommandType.StoredProcedure);
                
            }, TimeSpan.FromMinutes(15));
          
            return list;
        }
    }
}
