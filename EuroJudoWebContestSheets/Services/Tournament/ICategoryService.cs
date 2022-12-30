using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Services.Tournament;

public interface ICategoryService
{
    Task<CategoryDto?> CreateNewCategory(CreateCategoryDto categoryToCreate, CancellationToken ctx = default);
}