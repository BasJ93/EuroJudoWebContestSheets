using System.Collections.Generic;
using System.Linq;

namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public sealed record ContestOrderDto
    {
        public int Tatami { get; }
        public IList<ContestDto> Contests { get; } = new List<ContestDto>();
        
        public ContestOrderDto(int tatami, IEnumerable<ContestDto> contests)
        {
            Tatami = tatami;
            Contests = contests.ToList();
        }
    }
}
