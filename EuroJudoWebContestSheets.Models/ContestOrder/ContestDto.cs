namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public sealed record ContestDto
    {
        public int Number { get; set; }
        public string CompetitorWhite { get; set; } = string.Empty;
        public string CompetitorBlue { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Short { get; set; } = string.Empty;

        public ContestDto()
        {
            
        }

        public ContestDto(int number, string competitorWhite, string competitorBlue, string weight, string shortName)
        {
            Number = number;
            CompetitorWhite = competitorWhite;
            CompetitorBlue = competitorBlue;
            Weight = weight;
            Short = shortName;
        }
    }
}
