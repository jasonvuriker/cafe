using cafe.Domain.Entities;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cafe.Infrastructure.DataAccess.Repositories;

public class RoleRepository(CafeDbContext context) : Repository<Role>(context), IRoleRepository
{
    public async Task<Role?> GetByUserId(int userId)
    {
        return await context.Roles
            .Include(r=>r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(r => r.Users.Any(u => u.UserId == userId));
    }
}
