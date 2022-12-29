using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Services.Tournament;

public class TournamentService : ITournamentService
{
    private readonly ITournamentsRepository _tournaments;

    private readonly ICategoriesRepository _categories;
    
    public TournamentService(ICategoriesRepository categories, ITournamentsRepository tournaments)
    {
        _categories = categories;
        _tournaments = tournaments;
    }
    
    public async Task<IList<TournamentDto>> All(CancellationToken ctx = default)
    {
        IList<Database.Models.Tournament>? tournaments = await _tournaments.All(ctx);

        if (tournaments == null)
        {
            return new List<TournamentDto>();
        }

        return tournaments.Select(t => new TournamentDto(t.Id, t.TournamentName)).ToList();
    }

    public async Task<TournamentDto?> ById(int id, CancellationToken ctx = default)
    {
        Database.Models.Tournament? tournament = await _tournaments.GetById(id, ctx);

        if (tournament == null)
        {
            return default;
        }

        return new TournamentDto(tournament.Id, tournament.TournamentName);
    }

    public async Task<IList<CategoryDto>> CategoriesForTournament(int id, CancellationToken ctx = default)
    {
        IList<Category>? categories = await _categories.AllForTournament(id, ctx);

        if (categories == null)
        {
            return new List<CategoryDto>();
        }

        return categories.Select(c => new CategoryDto(c.Id, c.TournamentId, c.CategoryName)).ToList();
    }
}