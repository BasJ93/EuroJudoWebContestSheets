namespace EuroJudoWebContestSheets.Models.Tournament;

public sealed record CategoryWithSheetDataDto(int Id, int TournamentId, string Name) : CategoryDto(Id, TournamentId, Name)
{
    // Property for the actual ContestData 
}