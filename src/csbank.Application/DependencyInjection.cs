using CSBank.Application.Interfaces.Services;
using CSBank.Application.Services;
using CSBank.Domain.Services;
using CSBank.Domain.Services.Account;
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
        services.AddScoped<IDepositService, DepositService>();
        services.AddScoped<ITransferFundService, TransferFundService>();
        services.AddScoped<IUpdateUserService, UpdateUserService>();
        services.AddScoped<IReadTransactionHistory, ReadTransactionHistory>();
        services.AddScoped<IAuthService, AuthService>();

        //Domain Services
        services.AddScoped<UserDomainService>();
        services.AddScoped<AccountDomainService>();

        return services;
    }
}