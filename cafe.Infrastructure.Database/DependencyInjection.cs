using System.Reflection;
using cafe.Infrastructure.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Infrastructure.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CafeDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.Scan(r => r.FromAssembliesOf(typeof(IRepository<>))
            .AddClasses(filter => filter.Where(type => type.Name.EndsWith("Repository")))
            .AsMatchingInterface()
            .WithLifetime(ServiceLifetime.Scoped));

        return services;
    }

}
