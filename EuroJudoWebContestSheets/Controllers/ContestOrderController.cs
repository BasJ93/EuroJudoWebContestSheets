using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EuroJudoWebContestSheets.Controllers
{
    public class ContestOrderController : Controller
    {
        private IMemoryCache _memCache;

        public ContestOrderController(IMemoryCache memCache)
        {
            _memCache = memCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContestOrderLists()
        {

            List<ContestOrder> contestOrders = new List<ContestOrder>();

            if(!_memCache.TryGetValue("contestOrders", out contestOrders))
            {
                return NotFound();
            }

            return new JsonResult(contestOrders);
        }

        [HttpPost]
        public IActionResult PostContestOrderLists([FromBody] List<ContestOrder> contestOrders)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetPriority(CacheItemPriority.NeverRemove);

            _memCache.Set("contestOrders", contestOrders, cacheEntryOptions);

            return Ok();
        }
    }
}