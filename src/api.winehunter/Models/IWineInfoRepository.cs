using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.winehunter.Models
{
    public interface IWineInfoRepository
    {
        WineList Find(string upc);
    }
}
