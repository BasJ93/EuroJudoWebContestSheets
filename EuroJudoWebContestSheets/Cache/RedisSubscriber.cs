using System.Collections.Generic;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Extentions;
using EuroJudoWebContestSheets.Hubs;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.ContestOrder;
using EuroJudoWebContestSheets.Models.DTO;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace EuroJudoWebContestSheets.Cache
{
    public class RedisSubscriber : IRedisSubscriber
    {
        private readonly ISubscriber sub;
        private readonly IHubContext<ContestOrderHub> contestOrderHub;
        private readonly IHubContext<TournamentHub> tournamentHub;

        private static readonly string ContestOrderChannel = "contestOrder";
        private static readonly string TournamentChannel = "tournament";

        public RedisSubscriber(IConnectionMultiplexer redis, IHubContext<ContestOrderHub> contestOrder, IHubContext<TournamentHub> tournament)
        {
            sub = redis.GetSubscriber();
            this.contestOrderHub = contestOrder;
            this.tournamentHub = tournament;

            sub.SubscribeAsync(ContestOrderChannel, UpdateContestOrder);
            sub.SubscribeAsync(TournamentChannel, UpdateTournament);
        }

        public async Task PublishContestOrder(List<ContestOrder> contestOrders)
        {
            await sub.PublishAsync(ContestOrderChannel, JsonConvert.SerializeObject(contestOrders));
        }

        public async Task PublishTournament(RedisRoundRobinContestSheetDataDto contest)
        {
            await sub.PublishAsync(TournamentChannel, JsonConvert.SerializeObject(contest));
        }

        private void UpdateContestOrder(RedisChannel channel, RedisValue value)
        {
            string messageString = (string)value;
            List<ContestOrder> contestOrders = JsonConvert.DeserializeObject<List<ContestOrder>>(messageString);
            contestOrderHub.Clients.All.SendAsync("updateContestOrder", contestOrders);
        }

        private void UpdateTournament(RedisChannel channel, RedisValue value)
        {
            string messageString = (string)value;
            RedisRoundRobinContestSheetDataDto contestData = JsonConvert.DeserializeObject<RedisRoundRobinContestSheetDataDto>(messageString);
            if (contestData.ContestType == ContestType.RoundRobin)
            {
                tournamentHub.Clients.Group($"t{contestData.TournamentID}c{contestData.CategoryID}").SendAsync("updateSheet", contestData.ToRoundRobinDto());
            }
            else
            {
                tournamentHub.Clients.Group($"t{contestData.TournamentID}c{contestData.CategoryID}").SendAsync("updateSheet", contestData.ToDTO());
            }
        }
    }
}