using System.Reflection;
using cafe.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace cafe.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

}
