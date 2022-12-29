namespace EuroJudoWebContestSheets.Models.Tournament;

public record CategoryDto(int Id, int TournamentId, string Name)
{
    public string Name { get; } = Name;

    public int TournamentId { get; } = TournamentId;

    public int Id { get; } = Id;
}