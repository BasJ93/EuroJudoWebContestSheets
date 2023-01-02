using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Services.Tournament;

public interface ICategoryService
{
    Task<CategoryDto?> CreateNewCategory(CreateCategoryDto categoryToCreate, CancellationToken ctx = default);

    /// <summary>
    /// Get the Id for a category based on the tournament Id, the short name and the weight.
    /// </summary>
    /// <param name="idRequestDto">Request DTO</param>
    /// <param name="ctx">Cancellation token</param>
    /// <returns>The id if the category exists.</returns>
    Task<int?> GetIdByShortAndWeight(CategoryIdRequestDto idRequestDto, CancellationToken ctx = default);
}