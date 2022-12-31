namespace EuroJudoWebContestSheets.Models.Tournament;

public sealed record CategoryIdRequestDto(int TournamentId, string CategoryShort, string Weight)
{
    public int TournamentId { get; } = TournamentId;
    public string CategoryShort { get; } = CategoryShort;
    public string Weight { get; } = Weight;
}