using EuroJudoWebContestSheets.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Hubs
{
    public class TournamentHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"New SignalR client connected {Context.ConnectionId}");
            await Clients.Client(Context.ConnectionId).SendAsync("connected", "Hello");
            await base.OnConnectedAsync();
        }

        public async Task updateSheet(ContestSheetData contestData)
        {
            await Clients.All.SendAsync("updateSheet", contestData);
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
