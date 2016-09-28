using System.Linq;

namespace api.winehunter.Models
{
    public class WineInfoRepository : IWineInfoRepository
    {
        public WineList Find(string upc)
        {
            WineList wineItem;
            using (var db = new WineHunterContext())
            {
                wineItem = db.WineList
                    .First(wi => wi.UpcCode.ToLower().Trim() == upc.ToLower().Trim());
            }

            return wineItem;
        }
    }
}
