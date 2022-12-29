using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobin3 : RoundRobinBase
    {
        private const string template = "Poule3";

        public RoundRobin3(Category category) : base(category, template)
        {
            
        }
    }
}