using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Database.Repositories;

public class ApiKeyRepository : GenericCrudRepository<ApiKey>, IApiKeyRepository
{
    public ApiKeyRepository(ContestSheetDbContext db) : base(db)
    {
    }

    public async Task<ApiKey?> ByKey(Guid key, CancellationToken ctx = default)
    {
        return await Entities.Include(k => k.Roles).SingleOrDefaultAsync(k => k.Key == key, ctx);
    }
}