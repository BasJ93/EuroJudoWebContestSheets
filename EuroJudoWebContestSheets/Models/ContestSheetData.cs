using System;

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
        public int WazaariBlue { get; set; }
        public int ShidoBlue { get; set; }
        public bool ShowSimpleScore { get; set; }

        public void UpdateFromQuery(ContestSheetData queryData)
        {
            CompeditorWhite = String.IsNullOrEmpty(CompeditorWhite) ? queryData.CompeditorWhite : CompeditorWhite;
            CompeditorBlue = String.IsNullOrEmpty(CompeditorBlue) ? queryData.CompeditorBlue : CompeditorBlue ;
            IponWhite = queryData.IponWhite;
            WazaariWhite = queryData.WazaariWhite;
            ShidoWhite = queryData.ShidoWhite;
            IponBlue = queryData.IponBlue;
            WazaariBlue = queryData.WazaariBlue;
            ShidoBlue = queryData.ShidoBlue;
            ShowSimpleScore = queryData.ShowSimpleScore;
        }

    }
}
