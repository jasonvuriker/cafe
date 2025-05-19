using cafe.Application;
using cafe.Domain.Enums;
using cafe.Infrastructure.DataAccess;
using cafe.WebApi.Auth;
using cafe.WebApi.Extensions;
using cafe.WebApi.Middlewares;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerDocs()
    .AddJwtAuthentication(builder.Configuration)
    .AddDatabase(builder.Configuration)
    .AddApplication()
    .AddConfigurations(builder.Configuration);


builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
