using cafe.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace cafe.WebApi.Auth;

public class PermissionAuthorizationHandler() : AuthorizationHandler<PermissionAuthorizationPolicyRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionAuthorizationPolicyRequirement requirement)
    {
        var userId = context.User.Claims
            .FirstOrDefault(c => c.Type == "userId")?.Value;

        var permissions = context.User.Claims.Where(c => c.Type == AuthConstants.PermissionClaimType)
            .Select(c => c.Value)
            .ToList();

        if (permissions.Contains(requirement.Permission.ToString()))
        {
            context.Succeed(requirement);
        }
        else
        {
            throw new UnauthorizedAccessException();
        }
    }
}
