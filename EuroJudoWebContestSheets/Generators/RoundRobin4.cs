using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobin4 : RoundRobinBase
    {
        private const string template = "Poule4";

        public RoundRobin4(Category category) : base(category, template)
        {
        }
    }
}