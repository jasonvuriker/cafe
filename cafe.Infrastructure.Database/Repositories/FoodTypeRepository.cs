using cafe.Domain.Entities;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;

namespace cafe.Infrastructure.DataAccess.Repositories;

public class FoodTypeRepository(CafeDbContext context) 
    : Repository<FoodType>(context), IFoodTypeRepository;
