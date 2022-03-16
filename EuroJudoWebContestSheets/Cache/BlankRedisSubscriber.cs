using System.Collections.Generic;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models.ContestOrder;
using EuroJudoWebContestSheets.Models.DTO;
using StackExchange.Redis;

namespace EuroJudoWebContestSheets.Cache
{
    public class BlankRedisSubscriber : IRedisSubscriber
    {
        public BlankRedisSubscriber()
        {
        }

        public async Task PublishContestOrder(List<ContestOrder> contestOrders)
        {            
        }

        public async Task PublishTournament(RedisRoundRobinContestSheetDataDto contest)
        {            
        }

        private void UpdateContestOrder(RedisChannel channel, RedisValue value)
        {
        }

        private void UpdateTournament(RedisChannel channel, RedisValue value)
        {
        }
    }
}