namespace EuroJudoWebContestSheets.Database.Models
{
    public class ContestSheetData : BaseIdEntity
    {
        public int TournamentId { get; set; }
        public int CategoryId { get; set; }
        public int Contest { get; set; }
        public string? CompetitorWhite { get; set; }
        public string? CompetitorBlue { get; set; }
        public int? IponWhite { get; set; }
        public int? WazaariWhite { get; set; }
        public int? ShidoWhite { get; set; }
        public int? IponBlue { get; set; }
        public int? WazaariBlue { get; set; }
        public int? ShidoBlue { get; set; }
        public bool ShowSimpleScore { get; set; }
        
        public virtual Tournament? Tournament { get; set; }
        
        public virtual Category? Category { get; set; }

        public void UpdateFromQuery(ContestSheetData queryData)
        {
            CompetitorWhite = String.IsNullOrEmpty(CompetitorWhite) ? queryData.CompetitorWhite : CompetitorWhite;
            CompetitorBlue = String.IsNullOrEmpty(CompetitorBlue) ? queryData.CompetitorBlue : CompetitorBlue;
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
