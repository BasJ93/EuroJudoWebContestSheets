using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using EJUPublisher.Models;
using Microsoft.Extensions.Caching.Distributed;
using EuroJudoWebContestSheets.Cache;

namespace EuroJudoWebContestSheets.Hubs
{
    public class ContestOrderHub : Hub
    {
        private readonly IDistributedCache _cache;

        public ContestOrderHub(IDistributedCache cache)
        {
            _cache = cache;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Client(Context.ConnectionId).SendAsync("connected", "Hello from ContestOrderHub");
            
            List<ContestOrder>? contestOrders = await _cache.GetAsync<List<ContestOrder>>("contestOrders");
            
            if (contestOrders != default)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("updateContestOrder", contestOrders);
            }
        }

        public async Task updateContestOrder(List<ContestOrderDto> contestOrders)
        {
            await Clients.All.SendAsync("updateContestOrder", contestOrders);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
