using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Database.Repositories;

public sealed class TournamentsRepository : GenericCrudRepository<Tournament>, ITournamentsRepository
{
    public TournamentsRepository(ContestSheetDbContext db) : base(db)
    {
    }

    public async Task<Tournament?> ByName(string name, CancellationToken ctx = default)
    {
        return await Entities.SingleOrDefaultAsync(x => x.TournamentName == name, ctx);
    }
}