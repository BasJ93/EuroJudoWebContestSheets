using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Extensions;

public static class TournamentExtensions
{
    public static TournamentDto ToDto(this Tournament tournament)
    {
        return new TournamentDto(tournament.Id, tournament.TournamentName);
    }
}