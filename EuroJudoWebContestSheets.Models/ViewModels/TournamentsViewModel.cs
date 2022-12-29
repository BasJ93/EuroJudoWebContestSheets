using System.Collections.Generic;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Models.ViewModels;

public sealed record TournamentsViewModel(IList<TournamentDto> Tournaments)
{
    public IList<TournamentDto> Tournaments { get; } = Tournaments;
}