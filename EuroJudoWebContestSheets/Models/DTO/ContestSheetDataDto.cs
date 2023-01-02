namespace EuroJudoWebContestSheets.Models.DTO
{
    public class ContestSheetDataDto
    {
        public int Contest { get; set; }
        public string CompetitorWhite { get; set; } = string.Empty;
        public string CompetitorBlue { get; set; } = string.Empty;
        public int IponWhite { get; set; }
        public int WazaariWhite { get; set; }
        public int IponBlue { get; set; }
        public int WazaariBlue { get; set; }
    }
}
