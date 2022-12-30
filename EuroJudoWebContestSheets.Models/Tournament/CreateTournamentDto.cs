namespace EuroJudoWebContestSheets.Models.Tournament;

public sealed record CreateTournamentDto(string Name)
{
    public string Name { get; } = Name;
}