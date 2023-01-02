namespace EuroJudoWebContestSheets.Models.Tournament;

public sealed record CreateCategoryDto(string TournamentName, string Name, string Short, string Weight, int Size)
{
    public string TournamentName { get; } = TournamentName;
    public string Name { get; } = Name;
    public string Short { get; } = Short;
    public string Weight { get; } = Weight;
    public int Size { get; } = Size;
}