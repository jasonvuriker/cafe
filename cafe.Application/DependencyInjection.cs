using cafe.Application.FoodType.CreateFoodType;
using cafe.Application.Services;
using cafe.Domain.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace cafe.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(r => r.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IPermissionService, PermissionService>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateFoodTypeCommandValidator>();

        return services;
    }

}
