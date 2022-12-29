using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Database.Repositories.Interfaces;

public interface IContestSheetDataRepository : IGenericCrudRepository<ContestSheetData>
{
    Task<IList<ContestSheetData>?> AllForCategory(int categoryId, CancellationToken ctx = default);

    Task<ContestSheetData?> ByTournamentAndCategory(int tournamentId, int categoryId, int contest,
        CancellationToken ctx = default);
}