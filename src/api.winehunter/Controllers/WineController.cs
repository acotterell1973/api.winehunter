using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.winehunter.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.winehunter.Controllers
{
    [Route("api/[controller]")]
    public class WineController : Controller
    {
        private readonly IWineInfoRepository _wineInfoRepository;
        public WineController(IWineInfoRepository wineInfoRepository)
        {
            _wineInfoRepository = wineInfoRepository;
        }


        /// <summary>
        /// Gets the Wine Information By the Upc code
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        [HttpGet("{upc}", Name = "GetWineInfo")]
        public IActionResult GetByUpc(string upc)
        {
            var wineItem = _wineInfoRepository.Find(upc);

            if (wineItem == null)
            {
                return NotFound();
            }
            return new ObjectResult(wineItem);
        }


    }
}
