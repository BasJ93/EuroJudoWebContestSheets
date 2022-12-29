using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Database.Repositories;

public class CategoriesRepository : GenericCrudRepository<Category>, ICategoriesRepository
{
    public CategoriesRepository(ContestSheetDbContext db) : base(db)
    {
    }

    public async Task<IList<Category>?> AllForTournament(int tournamentId, CancellationToken ctx = default)
    {
        return await Entities.Where(c => c.TournamentId == tournamentId).AsNoTracking().ToListAsync(ctx);
    }

    public async Task<Category?> WithSheetData(int id, int tournamentId, CancellationToken ctx = default)
    {
        return await Entities.Include(x => x.SheetData)
            .FirstOrDefaultAsync(x => x.Id == id && x.TournamentId == tournamentId, ctx);
    }

    public async Task<Category?> ByShortAndWeight(int tournamentId, string categoryShort, string weight, CancellationToken ctx = default)
    {
        return await Entities.FirstOrDefaultAsync(
            c => c.TournamentId == tournamentId && c.Short == categoryShort && c.Weight == weight, ctx);
    }
}