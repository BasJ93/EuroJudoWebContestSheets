using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Database.Repositories;

public class ContestSheetDataRepository : GenericCrudRepository<ContestSheetData>, IContestSheetDataRepository
{
    public ContestSheetDataRepository(ContestSheetDbContext db) : base(db)
    {
    }

    public async Task<IList<ContestSheetData>?> AllForCategory(int categoryId, CancellationToken ctx = default)
    {
        return await Entities.Where(c => c.CategoryId == categoryId).ToListAsync(ctx);
    }

    public async Task<ContestSheetData?> ByTournamentAndCategory(int tournamentId, int categoryId, int contest, CancellationToken ctx = default)
    {
        return await Entities.SingleOrDefaultAsync(o => o.TournamentId == tournamentId && o.CategoryId == categoryId &&
                                           o.Contest == contest, ctx);
    }
}