using System.Collections.Generic;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models.ContestOrder;
using EuroJudoWebContestSheets.Models.DTO;

namespace EuroJudoWebContestSheets.Cache
{
    public interface IRedisSubscriber
    {
        public Task PublishContestOrder(List<ContestOrder> contestOrders);

        public Task PublishTournament(RedisRoundRobinContestSheetDataDto contest);
    }
}