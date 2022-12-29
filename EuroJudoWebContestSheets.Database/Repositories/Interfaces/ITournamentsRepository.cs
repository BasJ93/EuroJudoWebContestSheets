using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Database.Repositories.Interfaces;

public interface ITournamentsRepository : IGenericCrudRepository<Tournament>
{
    Task<Tournament?> ByName(string name, CancellationToken ctx = default);
}