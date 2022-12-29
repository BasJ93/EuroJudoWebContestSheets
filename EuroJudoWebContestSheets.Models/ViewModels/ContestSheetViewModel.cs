namespace EuroJudoWebContestSheets.Models.ViewModels;

public sealed record ContestSheetViewModel(string Title, int CategoryId, int TournamentId, string SvgText)
{
    public string Title { get; } = Title;
    public int CategoryId { get; } = CategoryId;
    public int TournamentId { get; }= TournamentId;
    public string SvgText { get; } = SvgText;
}