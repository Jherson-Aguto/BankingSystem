using Microsoft.Extensions.DependencyInjection;

namespace CSbank.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
    (this IServiceCollection services)
    {
        return services;
    }
}