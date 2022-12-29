using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobin6 : RoundRobinBase
    {
        private const string template = "Poule5";

        public RoundRobin6(Category category) : base(category, template)
        {

        }
    }
}