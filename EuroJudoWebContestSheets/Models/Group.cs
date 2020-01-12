using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Models
{
    public class Group
    {
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public int EventNumber { get; set; }
        public string Name { get; set; }
        public bool Teams { get; set; }
        public int UseCompetition { get; set; }
        public int UseCompetitionWithFinals { get; set; }
        public string Short { get; set; }
        public string System { get; set; }
    }
}
