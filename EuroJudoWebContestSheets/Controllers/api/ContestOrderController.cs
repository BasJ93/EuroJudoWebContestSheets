using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Authorization;
using EuroJudoWebContestSheets.Cache;
using EuroJudoWebContestSheets.Hubs;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;

namespace EuroJudoWebContestSheets.Controllers.api;

/// <summary>
/// API controller for the contest order related data.
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class ContestOrderController : ControllerBase
{
    private readonly IDistributedCache _cache;
    private readonly IHubContext<ContestOrderHub> _hub;

    public ContestOrderController(IDistributedCache cache, IHubContext<ContestOrderHub> hub)
    {
        _hub = hub;
        _cache = cache;
    }
    
    /// <summary>
    /// Endpoint for the client app to retrieve the current set of contest orders for each tatami.
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns>A JSON representation of a list of <see cref="ContestOrder"/></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ContestOrder>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ContestOrderLists(CancellationToken ctx)
    {
        List<ContestOrder> contestOrders = await _cache.GetAsync<List<ContestOrder>>("contestOrders", ctx);
            
        if (contestOrders == default)
        {
            return NotFound();
        }

        return new JsonResult(contestOrders);
    }

    /// <summary>
    /// Endpoint for the uploader client to submit the current set of contest orders.
    /// </summary>
    /// <param name="contestOrders">The JSON representation of the current list of <see cref="ContestOrder"/> for each tatami.</param>
    /// <param name="ctx"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(Policy = Policies.Uploader)]
    public async Task<IActionResult> PostContestOrderLists([FromBody] List<ContestOrder> contestOrders, CancellationToken ctx)
    {
        await _cache.SetAsync("contestOrders", contestOrders, ctx);
        await _hub.Clients.All.SendAsync("updateContestOrder", contestOrders, ctx);

        return Ok();
    }
}