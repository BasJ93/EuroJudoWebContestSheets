using System.Collections.Generic;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Cache;
using EuroJudoWebContestSheets.Hubs;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EuroJudoWebContestSheets.Controllers
{
    public class ContestOrderController : Controller
    {
        private readonly IRedisSubscriber _subscriber;
        private readonly ICacheHelper _cache;
        private readonly IHubContext<ContestOrderHub> _hub;

        public ContestOrderController(ICacheHelper cache, IHubContext<ContestOrderHub> hub,  IRedisSubscriber subscriber)
        {
            _hub = hub;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContestOrderLists()
        {

            List<ContestOrder> contestOrders = new List<ContestOrder>();

            if (!_cache.TryGetValue("contestOrders", out contestOrders))
            {
                return NotFound();
            }

            return new JsonResult(contestOrders);
        }

        [HttpPost]
        public async Task<IActionResult> PostContestOrderLists([FromBody] List<ContestOrder> contestOrders)
        {
            await _cache.SetCache<List<ContestOrder>>("contestOrders", contestOrders);
            await _subscriber.PublishContestOrder(contestOrders);
            await _hub.Clients.All.SendAsync("updateContestOrder", contestOrders);

            return Ok();
        }

        
    }
}