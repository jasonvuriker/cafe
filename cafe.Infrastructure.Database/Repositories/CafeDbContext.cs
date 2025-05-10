using cafe.Domain.Entities;
using cafe.Domain.Helper;
using Microsoft.EntityFrameworkCore;

namespace cafe.Infrastructure.DataAccess.Repositories;

public class CafeDbContext(DbContextOptions<CafeDbContext> options) : DbContext(options)
{
    public DbSet<FoodType> FoodTypes { get; set; }

    public DbSet<Food> Foods { get; set; }

    public DbSet<User?> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasOne(r => r.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(r => r.RoleId);

            //builder.HasData(new User[]
            //{
            //    new User()
            //    {
            //        UserId = 1,
            //        Username = "super_admin",
            //        Email = "super_admin@yandex.ru",
            //        PasswordHash = "6B8BB5EAE345018F01DC8F5E516EA5E0A79E2F901A0AE6B780A822F413B2D22B-C13C751C14D8A31B1978EA7E4B139146",
            //        IsActive = true,
            //        RoleId = 1,
            //    }
            //});
        });

        modelBuilder.Entity<Role>(builder =>
        {
            builder.HasMany(r => r.Permissions)
                .WithMany();

            builder.HasData(new Role[]
            {
                new Role()
                {
                    RoleId = 1,
                    Name = "super_admin",
                    IsActive = true,
                },
                new Role()
                {
                    RoleId = 2,
                    Name = "user",
                    IsActive = true,
                }
            });
        });
    }
}
