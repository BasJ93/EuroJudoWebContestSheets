namespace EuroJudoWebContestSheets.Models.Tournament;

public sealed record TournamentDto(int Id, string Name)
{
    public int Id { get; } = Id;
    public string Name { get; } = Name;
}