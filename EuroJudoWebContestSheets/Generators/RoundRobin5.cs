using EuroJudoWebContestSheets.Models;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobin5 : RoundRobinBase
    {
        private const string template = "Poule5";

        public RoundRobin5(Category category) : base(category, template)
        {
            
        }
    }
}