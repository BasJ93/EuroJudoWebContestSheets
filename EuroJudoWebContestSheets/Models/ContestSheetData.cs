using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Models
{
    public class ContestSheetData
    {
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public int CategoryID { get; set; }
        public int Contest { get; set; }
        public string CompeditorWhite { get; set; }
        public string CompeditorBlue { get; set; }
        public int IponWhite { get; set; }
        public int WazaariWhite { get; set; }
        public int ShidoWhite { get; set; }
        public int IponBlue { get; set; }
        public int WazaarieBlue { get; set; }
        public int ShidoBlue { get; set; }
        public bool ShowSimpleScore { get; set; }
    }
}
