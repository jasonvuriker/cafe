using cafe.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace cafe.WebApi.Auth;

public class PermissionAuthorizationProvider(IOptions<AuthorizationOptions> options)
    : DefaultAuthorizationPolicyProvider(options)
{
    public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = new AuthorizationPolicyBuilder();

        var permissions = policyName.Split(',');

        foreach (var permission in permissions)
        {
            var permissionType = Enum.Parse<PermissionType>(permission);

            policy.AddRequirements(new PermissionAuthorizationPolicyRequirement(permissionType));
        }


        return Task.FromResult(policy.Build());
    }
}
