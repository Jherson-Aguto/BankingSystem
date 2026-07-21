using CSbank.Domain.Services;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSBank.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IReadUserService, ReadUserService>();
        services.AddScoped<IRegisterCustomerService, RegisterCustomerService>();
        services.AddScoped<IRegisterAccountsService, RegisterAccountsService>();

        services.AddScoped<RegisterServiceDomain>();

        return services;
    }
}