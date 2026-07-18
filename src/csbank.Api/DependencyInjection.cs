using CSbank.Domain.Services;
using CSbank.Infrastructure.Repositories.Dapper;
using CSBank.Application.Interfaces;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Services;

namespace CSBank.Api.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //domain layer
        services.AddScoped<RegisterServiceDomain>();
        //

        services.AddScoped<IRegisterService, RegisterCustomerService>();
        services.AddScoped<IReadUserRepository, ReadUserRepository>();
        services.AddScoped<IReadUserService, ReadUserService>();

        return services;
    }

}