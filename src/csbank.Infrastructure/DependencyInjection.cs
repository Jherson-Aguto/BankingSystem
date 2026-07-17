using CSbank.Infrastructure.Repositories.Dapper;
using CSBank.Application.Interfaces.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace CSbank.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
    (this IServiceCollection services)
    {
        services.AddScoped<ISaveUserRepository, SaveUserRepository>();
        return services;
    }
}