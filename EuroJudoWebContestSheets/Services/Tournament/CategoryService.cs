using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using EuroJudoWebContestSheets.Extensions;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Services.Tournament;

public sealed class CategoryService : ICategoryService
{
    private readonly ITournamentsRepository _tournaments;
    private readonly ICategoriesRepository _categories;

    public CategoryService(ITournamentsRepository tournaments, ICategoriesRepository categories)
    {
        _tournaments = tournaments;
        _categories = categories;
    }

    public async Task<CategoryDto?> CreateNewCategory(CreateCategoryDto categoryToCreate,
        CancellationToken ctx = default)
    {
        Database.Models.Tournament? tournament = await _tournaments.ByName(categoryToCreate.TournamentName, ctx);

        if (tournament == null)
        {
            return null;
        }

        Category category = new Category()
        {
            CategoryName = categoryToCreate.Name,
            Tournament = tournament,
            Short = categoryToCreate.Short,
            Weight = categoryToCreate.Weight,
            SheetSize = categoryToCreate.Size,
        };
        
        category = await _categories.Insert( category, ctx);

        return category.ToDto();
    }
}