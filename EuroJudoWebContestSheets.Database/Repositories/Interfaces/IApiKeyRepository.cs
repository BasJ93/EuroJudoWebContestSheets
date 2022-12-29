using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Database.Repositories.Interfaces;

public interface IApiKeyRepository : IGenericCrudRepository<ApiKey>
{
    Task<ApiKey?> ByKey(Guid key, CancellationToken ctx = default);
}