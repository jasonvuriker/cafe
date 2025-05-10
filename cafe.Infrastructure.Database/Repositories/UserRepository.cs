using cafe.Domain.Entities;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cafe.Infrastructure.DataAccess.Repositories;

public class UserRepository(CafeDbContext context) 
    : Repository<User>(context), IUserRepository
{
    public IQueryable<User?> GetAllActive()
    {
        return context.Users.Where(u => u.IsActive);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
    }
}
