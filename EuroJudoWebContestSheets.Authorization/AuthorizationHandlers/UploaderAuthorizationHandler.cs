using EuroJudoWebContestSheets.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace EuroJudoWebContestSheets.Authorization.AuthorizationHandlers
{
    public class UploaderAuthorizationHandler : AuthorizationHandler<UploaderRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            UploaderRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Uploader))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}