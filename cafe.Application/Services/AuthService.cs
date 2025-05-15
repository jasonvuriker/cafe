using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using cafe.Application.Options;
using cafe.Domain.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace cafe.Application.Services;

public class AuthService(IOptions<JwtSettings> settings, IPermissionService permissionService) : IAuthService
{
    private readonly IOptions<JwtSettings> _settings = settings;
    private readonly JwtSecurityTokenHandler _handler = new();

    public async Task<string> GetToken(int userId, string username)
    {
        var permissions = await permissionService.GetUserPermissions(userId);

        var claims = permissions
            .Select(permission => new Claim("permissions", permission))
            .ToList();

        claims.Add(new Claim(JwtRegisteredClaimNames.NameId, userId.ToString()));
        
        claims.Add(new Claim(nameof(RoleType.Chief),""));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            "cafe.uz",
            "cafe.uz",
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: credentials
        );

        return _handler.WriteToken(token);
    }
}
