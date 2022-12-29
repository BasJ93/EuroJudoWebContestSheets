using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Services.Tournament;

public interface ITournamentService
{
    Task<IList<TournamentDto>> All(CancellationToken ctx = default);

    Task<TournamentDto?> ById(int id, CancellationToken ctx = default);
    
    Task<IList<CategoryDto>> CategoriesForTournament(int id, CancellationToken ctx = default);
    
    
}