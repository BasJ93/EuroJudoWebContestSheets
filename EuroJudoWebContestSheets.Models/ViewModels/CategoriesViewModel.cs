using System.Collections.Generic;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EuroJudoWebContestSheets.Models.ViewModels;

public sealed record CategoriesViewModel(IList<CategoryDto> Categories, string Name)
{
    public string Name { get; } = Name;
    public IList<CategoryDto> Categories { get; } = Categories;
}