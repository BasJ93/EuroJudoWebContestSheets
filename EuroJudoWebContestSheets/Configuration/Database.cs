using EuroJudoWebContestSheets.Database;
using EuroJudoWebContestSheets.Database.Repositories;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EuroJudoWebContestSheets.Configuration;

public static class Database
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ContestSheetDbContext>();

        services.AddScoped<ITournamentsRepository, TournamentsRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IContestSheetDataRepository, ContestSheetDataRepository>();
        services.AddScoped<IApiKeyRepository, ApiKeyRepository>();

        return services;
    }
}