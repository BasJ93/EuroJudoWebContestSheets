using EuroJudoWebContestSheets.Authentication;
using EuroJudoWebContestSheets.Authorization;
using EuroJudoWebContestSheets.Authorization.AuthorizationHandlers;
using EuroJudoWebContestSheets.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace EuroJudoWebContestSheets.Configuration;

public static class Authentication
{
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            })
            .AddApiKeySupport(options => { });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.Admin, policy => policy.Requirements.Add(new AdminRequirement()));
            options.AddPolicy(Policies.Uploader, policy => policy.Requirements.Add(new UploaderRequirement()));
        });

        services.AddSingleton<IAuthorizationHandler, AdminAuthorizationHandler>();
        services.AddSingleton<IAuthorizationHandler, UploaderAuthorizationHandler>();

        return services;
    }
}