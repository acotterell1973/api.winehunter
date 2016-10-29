using System.Threading.Tasks;
using api.dataaccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.winehunter.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        internal IWineService _wineService;

        public BaseController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [HttpGet("cache/clear")]
        public async Task<IActionResult> ClearCache()
        {
            await _wineService.ClearCacheAsync();
            return Ok();
        }
    }
}
