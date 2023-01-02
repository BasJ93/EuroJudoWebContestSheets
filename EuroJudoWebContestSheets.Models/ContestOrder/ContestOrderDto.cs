using System.Collections.Generic;
using System.Linq;

namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public sealed record ContestOrderDto
    {
        public int Tatami { get; set; }
        public IList<ContestDto> Contests { get; set; } = new List<ContestDto>();
        
        public ContestOrderDto(int tatami, IList<ContestDto> contests)
        {
            Tatami = tatami;
            Contests = contests;
        }
        
        public ContestOrderDto(int tatami, IEnumerable<ContestDto> contests)
        {
            Tatami = tatami;
            Contests = contests.ToList();
        }

        public ContestOrderDto()
        {
            
        }
    }
}
