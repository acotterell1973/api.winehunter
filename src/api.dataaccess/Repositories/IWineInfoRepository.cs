using System.Collections.Generic;
using System.Threading.Tasks;
using api.dataaccess.Entities;

namespace api.dataaccess.Repositories
{
    public interface IWineInfoRepository : IRepository<WineInfo>
    {
        Task<WineInfo> FindByUpcAsync(string upc);
        Task<List<WineInfo>> FindByProducerAsync(string producer);
    }
}
