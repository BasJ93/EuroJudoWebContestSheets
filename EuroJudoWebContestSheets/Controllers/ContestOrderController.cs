using System.Collections.Generic;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Hubs;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace EuroJudoWebContestSheets.Controllers
{
    public class ContestOrderController : Controller
    {
        private IMemoryCache _memCache;
        private readonly IHubContext<ContestOrderHub> _hub;

        public ContestOrderController(IMemoryCache memCache, IHubContext<ContestOrderHub> hub)
        {
            _hub = hub;
            _memCache = memCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContestOrderLists()
        {

            List<ContestOrderDto> contestOrders = new List<ContestOrderDto>();

            if(!_memCache.TryGetValue("contestOrders", out contestOrders))
            {
                return NotFound();
            }

            return new JsonResult(contestOrders);
        }

        [HttpPost]
        public async Task<IActionResult> PostContestOrderLists([FromBody] List<ContestOrderDto> contestOrders)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetPriority(CacheItemPriority.Normal);

            _memCache.Set("contestOrders", contestOrders, cacheEntryOptions);
            await _hub.Clients.All.SendAsync("updateContestOrder", contestOrders);

            return Ok();
        }
    }
}