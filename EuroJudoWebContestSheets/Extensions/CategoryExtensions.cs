using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Extensions;

public static class CategoryExtensions
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(category.Id, category.TournamentId, category.CategoryName);
    }
}