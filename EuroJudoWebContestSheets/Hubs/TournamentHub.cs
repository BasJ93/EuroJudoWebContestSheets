using EuroJudoWebContestSheets.Extentions;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Database.Models;

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

        public async Task UpdateSheet(ContestSheetData contestData)
        {
            //await Clients.All.SendAsync("updateSheet", contestData);

            await Clients.Group(contestData.GroupName()).SendAsync("updateSheet", contestData);
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
