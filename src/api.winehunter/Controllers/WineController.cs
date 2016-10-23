using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dataaccess.Repositories;
using api.dataaccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.winehunter.Controllers
{
    [Route("api/[controller]")]
    public class WineController : Controller
    {
        private readonly IWineService _wineService;
      
        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        /// <summary>
        /// Gets the Wine Information By the Upc code
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        [HttpGet("upc/{upc}", Name = "GetWineInfo")]
        public async Task<IActionResult> GetByUpc(string upc)
        {
            var wineItem = await _wineService.FindByUpcAsync(upc);

            if (wineItem == null)
            {
                return NotFound();
            }
            return new ObjectResult(wineItem);
        }

        [HttpGet("producer/{producer}", Name = "GetWineInfoByProducer")]
        public async Task<IActionResult> GetByProducer(string producer)
        {
            var wineItem = await _wineService.FindByProducerAsync(producer);

            if (wineItem == null)
            {
                return NotFound();
            }
            return new ObjectResult(wineItem);
        }
    }
}
