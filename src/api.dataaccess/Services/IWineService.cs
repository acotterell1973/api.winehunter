using System.Collections.Generic;
using System.Threading.Tasks;
using api.dataaccess.Entities;

namespace api.dataaccess.Services
{
    public interface IWineService
    {
        Task<WineInfo> FindByUpcAsync(string upc);
        Task<List<WineInfo>> FindByProducerAsync(string producer);
    }
}