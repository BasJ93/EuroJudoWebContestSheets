using EuroJudoWebContestSheets.Services.Tournament;
using Microsoft.Extensions.DependencyInjection;

namespace EuroJudoWebContestSheets.Configuration;

public static class ServiceLayers
{
    public static IServiceCollection AddServiceLayers(this IServiceCollection services)
    {
        services.AddScoped<ITournamentService, TournamentService>();
        services.AddScoped<ICategoryService, CategoryService>();
        
        return services;
    }
}