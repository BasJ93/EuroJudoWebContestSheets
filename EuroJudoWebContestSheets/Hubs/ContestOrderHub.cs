using EuroJudoWebContestSheets.Cache;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Hubs
{
    public class ContestOrderHub : Hub
    {
        private readonly ICacheHelper cache;

        public ContestOrderHub(ICacheHelper cache)
        {
            this.cache = cache;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Client(Context.ConnectionId).SendAsync("connected", "Hello from ContestOrderHub");
            if (!cache.TryGetValue("contestOrders", out List<ContestOrder> contestOrders))
            {
                await cache.SetCache<List<ContestOrder>>("contestOrders", contestOrders);
            }
        }

        public async Task updateContestOrder(List<ContestOrder> contestOrders)
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
