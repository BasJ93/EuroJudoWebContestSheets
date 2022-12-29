namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public sealed record ContestDto
    {
        public int Number { get; }
        public string CompetitorWhite { get; }
        public string CompetitorBlue { get; }
        public string Weight { get; }
        public string Short { get; }

        public ContestDto(int number, string white, string blue, string weight, string shortDesc)
        {
            Number = number;
            CompetitorWhite = white;
            CompetitorBlue = blue;
            Weight = weight;
            Short = shortDesc;
        }
    }
}
