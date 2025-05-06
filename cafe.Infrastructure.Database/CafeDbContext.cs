using cafe.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace cafe.Infrastructure.DataAccess;

public class CafeDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<FoodType> FoodTypes { get; set; }

    public DbSet<Food> Foods { get; set; }
}
