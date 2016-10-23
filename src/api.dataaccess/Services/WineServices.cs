using System.Collections.Generic;
using System.Threading.Tasks;
using api.dataaccess.Entities;
using api.dataaccess.UnitOfWork;

namespace api.dataaccess.Services
{
    public class WineServices : IWineService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WineServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<WineInfo> FindByUpcAsync(string upc)
        {
            return await _unitOfWork.WineInfoRepository.FindByUpcAsync(upc);
        }

        public async Task<List<WineInfo>> FindByProducerAsync(string producer)
        {
            return await _unitOfWork.WineInfoRepository.FindByProducerAsync(producer);
        }
    }
}
