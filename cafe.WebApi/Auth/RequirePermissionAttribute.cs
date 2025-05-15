using cafe.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace cafe.WebApi.Auth;

public class RequirePermissionAttribute : AuthorizeAttribute
{
    public RequirePermissionAttribute(params PermissionType[] permissions)
    {
        Policy = string.Join(",", permissions.Select(p => p.ToString()));
    }
}
