using CSbank.Domain.Services;
using CSbank.Domain.Services.Account;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSBank.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Application Services
        services.AddScoped<IReadUserService, ReadUserService>();
        services.AddScoped<IRegisterCustomerService, RegisterCustomerService>();
        services.AddScoped<IRegisterAccountsService, RegisterAccountsService>();

        //Domain Services
        services.AddScoped<UserDomainService>();
        services.AddScoped<AccountDomainService>();

        return services;
    }
}