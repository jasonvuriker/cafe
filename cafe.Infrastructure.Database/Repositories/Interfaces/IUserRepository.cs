using cafe.Domain.Entities;

namespace cafe.Infrastructure.DataAccess.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    IQueryable<User?> GetAllActive();

    Task<User?> GetByUsernameAsync(string username);
}
