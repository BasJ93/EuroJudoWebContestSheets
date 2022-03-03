using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EuroJudoWebContestSheets.Authorization
{
    public class UploaderAuthorizationHandler : AuthorizationHandler<UploaderRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UploaderRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Uploader))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
        }
    }
}