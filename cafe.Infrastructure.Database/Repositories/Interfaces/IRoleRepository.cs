using cafe.Domain.Entities;

namespace cafe.Infrastructure.DataAccess.Repositories.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByUserId(int userId);
}
