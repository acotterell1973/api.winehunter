using System.Linq;
using api.winehunter.DbModels;

namespace api.winehunter.Models
{
    public class WineInfoRepository : IWineInfoRepository
    {
        public WineInfo Find(string upc)
        {
            WineInfo wineInfo;
            using (var db = new WineHunterContext())
            {

                var wi = from wl in db.WineList
                         join wv in db.WineVarieties on wl.WineVarietiesVarietyId equals wv.VarietyId
                         where wl.Upc == upc
                         select new WineInfo
                         {
                             Upc = wl.Upc,
                             Producer = wl.Producer,
                             VarietyName = wv.Name,
                             WineListId = wl.WineListId,
                             Region = wl.Region,
                             Vintage = wl.Vintage
                         };

                wineInfo = wi.First();

            }

            return wineInfo;
        }
    }
}
