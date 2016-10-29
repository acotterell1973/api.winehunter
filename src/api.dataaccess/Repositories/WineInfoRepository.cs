using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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


        public WineInfoBaseRepository(IConnectionFactory connectionFactory, ICacheProvider cacheProvider )
        {
            _connectionFactory = connectionFactory;
            _cacheProvider = cacheProvider;
        }

        public WineInfo FindByUpc(string upc)
        {
            WineInfo wineInfo;
            //using (var db = new WineHunterContext())
            //{

            //    var wi = from wl in db.WineList.AsNoTracking()
            //             join wv in db.WineVarieties.AsNoTracking() on wl.WineVarietiesVarietyId equals wv.VarietyId
            //             where wl.Upc == upc
            //             select new WineInfo
            //             {
            //                 Upc = wl.Upc,
            //                 Producer = wl.Producer,
            //                 VarietyName = wv.Name,
            //                 WineListId = wl.WineListId,
            //                 Region = wl.Region,
            //                 Vintage = wl.Vintage
            //             };

            //    wineInfo = wi.First();

            //}

            return null;
        }

        public List<WineInfo> FindByProducer(string producer)
        {
            List<WineInfo> wineInfo;
            //using (var db = new WineHunterContext())
            //{

            //    wineInfo = (from wl in db.WineList.AsNoTracking()
            //             join wv in db.WineVarieties.AsNoTracking() on wl.WineVarietiesVarietyId equals wv.VarietyId
            //             where wl.Producer == producer
            //             select new WineInfo
            //             {
            //                 Upc = wl.Upc,
            //                 Producer = wl.Producer,
            //                 VarietyName = wv.Name,
            //                 WineListId = wl.WineListId,
            //                 Region = wl.Region,
            //                 Vintage = wl.Vintage
            //             }).ToList();
            //}

            return null;
        }

        public async Task<WineInfo> FindByUpcAsync(string upc)
        {
            var query = "GetWineVarieties";
            var param = new DynamicParameters();
            param.Add("@upc", upc);

            var wineInfo = await SqlMapper.QueryFirstAsync<WineInfo>(_connectionFactory.GetConnection,
                query,
                param,
                commandType: CommandType.StoredProcedure);

            return wineInfo;
        }

        public async Task<List<WineInfo>> FindByProducerAsync(string producer)
        {
            var query = "GetWineVarieties";
            var param = new DynamicParameters();
            param.Add("@producer", producer);

            var list = await SqlMapper.QueryAsync<WineInfo>(_connectionFactory.GetConnection,
                query, 
                param, 
                commandType: CommandType.StoredProcedure);
            return list as List<WineInfo>;
        }
    }
}
