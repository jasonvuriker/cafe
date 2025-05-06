using cafe.Domain.Entities;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;

namespace cafe.Infrastructure.DataAccess.Repositories;

public class FoodRepository(CafeDbContext context) 
    : Repository<Food>(context), IFoodRepository;
