using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public class ContestOrder
    {
        public int Tatami { get; set; }
        public List<Contest> Contests { get; set; }
    }
}
