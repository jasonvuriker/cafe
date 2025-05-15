using cafe.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace cafe.WebApi.Auth;

public class PermissionAuthorizationPolicyRequirement(PermissionType permissionType) : IAuthorizationRequirement
{
    public PermissionType Permission { get; set; } = permissionType;
}
