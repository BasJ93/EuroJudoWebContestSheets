using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EuroJudoWebContestSheets.Authorization
{
    public class AdminAuthorizationHandler : AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Admin))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
        }
    }
}