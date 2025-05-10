using System.Reflection;
using cafe.Application.Services;
using cafe.Domain.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

}
