using CSBank.Application.Interfaces;
using CSBank.Application.Services;

namespace CSBank.Api.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterCustomer, RegisterCustomerService>();

        return services;
    }

}