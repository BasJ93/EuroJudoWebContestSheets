namespace EuroJudoWebContestSheets.Models.Tournament;

public sealed record UploadContestResultDto(int TournamentId, int CategoryId, int Contest, string? CompetitorWhite,
    string? CompetitorBlue, int? ScoreWhite, int? ScoreBlue, bool ShowSimpleScore)
{
    public int TournamentId { get; } = TournamentId;
    public int CategoryId { get; } = CategoryId;
    public int Contest { get; } = Contest;
    public string? CompetitorWhite { get; } = CompetitorWhite;
    public string? CompetitorBlue { get; } = CompetitorBlue;
    public int? ScoreWhite { get; } = ScoreWhite;
    public int? ScoreBlue { get; } = ScoreBlue;
    public bool ShowSimpleScore { get; } = ShowSimpleScore;
}