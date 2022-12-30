namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public sealed record ContestDto(int Number, string CompetitorWhite, string CompetitorBlue, string Weight, string Short)
    {
        public int Number { get; } = Number;
        public string CompetitorWhite { get; } = CompetitorWhite;
        public string CompetitorBlue { get; } = CompetitorBlue;
        public string Weight { get; } = Weight;
        public string Short { get; } = Short;
    }
}
