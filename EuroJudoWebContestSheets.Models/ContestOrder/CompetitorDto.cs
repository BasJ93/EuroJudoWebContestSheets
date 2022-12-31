namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public sealed record CompetitorDto(string Name, string FirstName, string MiddleName)
    {
        public string Name { get; set; } = Name;
        public string FirstName { get; set; } = FirstName;
        public string MiddleName { get; set; } = MiddleName;
    }
}
