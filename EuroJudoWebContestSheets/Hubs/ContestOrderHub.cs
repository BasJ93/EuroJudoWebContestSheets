using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Hubs
{
    public class ContestOrderHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("connected", "Hello from ContestOrderHub");
            await base.OnConnectedAsync();
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
