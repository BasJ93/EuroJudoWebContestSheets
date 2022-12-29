using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Database.Repositories.Interfaces;

public interface ICategoriesRepository : IGenericCrudRepository<Category>
{
    Task<IList<Category>?> AllForTournament(int tournamentId, CancellationToken ctx = default);

    Task<Category?> WithSheetData(int id, int tournamentId, CancellationToken ctx = default);

    Task<Category?> ByShortAndWeight(int tournamentId, string categoryShort, string weight, CancellationToken ctx = default);
}