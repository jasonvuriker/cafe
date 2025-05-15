using cafe.Domain.Entities;
using cafe.Domain.Enums;
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
        });

        modelBuilder.Entity<RolePermission>(builder =>
        {
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId })
                .HasName("pk_role_id_permission_id");

            //builder.HasOne<Role>()
            //    .WithMany(r => r.RolePermissions)
            //    .HasForeignKey(r => r.RoleId);

            //builder.HasOne<Permission>()
            //    .WithMany(r => r.RolePermissions)
            //    .HasForeignKey(r => r.PermissionId);
        });

        modelBuilder.Entity<Permission>(builder =>
        {
            builder.HasMany(r => r.RolePermissions)
                .WithOne(r => r.Permission)
                .HasForeignKey(r => r.PermissionId);

            builder.HasData([
                new Permission()
                {
                    PermissionId = 1,
                    Name = nameof(PermissionType.ViewFoodPermission),
                },
                new Permission()
                {
                    PermissionId = 2,
                    Name = nameof(PermissionType.InsertFoodPermission),
                },
                new Permission()
                {
                    PermissionId = 3,
                    Name = nameof(PermissionType.DeleteFoodPermission),
                },
                new Permission()
                {
                    PermissionId = 4,
                    Name = nameof(PermissionType.ViewFoodPermission),
                },
                new Permission()
                {
                    PermissionId = 5,
                    Name = nameof(PermissionType.InsertMenuPermission),
                },
                new Permission()
                {
                    PermissionId = 6,
                    Name = nameof(PermissionType.DeleteMenuPermission),
                },
                new Permission()
                {
                    PermissionId = 7,
                    Name = nameof(PermissionType.ViewMenuPermission),
                },
                new Permission()
                {
                    PermissionId = 8,
                    Name = nameof(PermissionType.InsertUserPermission),
                },
                new Permission()
                {
                    PermissionId = 9,
                    Name = nameof(PermissionType.DeleteUserPermission),
                },
                new Permission()
                {
                    PermissionId = 10,
                    Name = nameof(PermissionType.ViewUserPermission),
                },
            ]);
        });

        modelBuilder.Entity<Role>(builder =>
        {
            builder.HasMany(r => r.RolePermissions)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId);

            builder.HasData(new Role[]
            {
                new Role()
                {
                    RoleId = 1,
                    Name = nameof(RoleType.Admin),
                    IsActive = true,
                },
                new Role()
                {
                    RoleId = 2,
                    Name = nameof(RoleType.Manager),
                    IsActive = true,
                },
                new Role()
                {
                    RoleId = 3,
                    Name = nameof(RoleType.Chief),
                    IsActive = true,
                },
                new Role()
                {
                    RoleId = 4,
                    Name = nameof(RoleType.Waiter),
                    IsActive = true,
                },
                new Role()
                {
                    RoleId = 5,
                    Name = nameof(RoleType.Hr),
                    IsActive = true,
                },
            });
        });

        modelBuilder.Entity<RolePermission>(builder =>
        {
            builder.HasData([
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 1,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 2,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 3,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 4,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 5,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 6,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 7,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 8,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 9,
                },
                new RolePermission()
                {
                    RoleId = 1,
                    PermissionId = 10,
                },
            ]);
        });
    }
}
