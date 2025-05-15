using cafe.Infrastructure.DataAccess.Repositories.Interfaces;

namespace cafe.Application.Services;

public class PermissionService(IRoleRepository roleRepository) : IPermissionService
{
    public async Task<List<string>> GetUserPermissions(int userId)
    {
        var role = await roleRepository.GetByUserId(userId);

        if (role == null)
        {
            return new List<string>();
        }

        return role.RolePermissions.Select(r => r.Permission.Name).ToList();
    }
}
