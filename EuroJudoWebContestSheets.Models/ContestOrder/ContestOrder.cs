using System.Collections.Generic;

namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public class ContestOrderDto
    {
        public int Tatami { get; set; }
        public List<ContestDto> Contests { get; set; }
    }
}
