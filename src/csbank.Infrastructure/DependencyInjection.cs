using System.Data;
using CSbank.Infrastructure.Configurations;
using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Repositories.Dapper;
using CSBank.Application.Interfaces.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace CSbank.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
    (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveUserRepository, SaveUserRepository>();
        services.AddScoped<IReadUserRepository, ReadUserRepository>();
        services.AddScoped<ISaveAccountsRepository, SaveAccountsRepository>();
        services.AddScoped<HelperFunctions>();

        //connection
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var builder = new NpgsqlDataSourceBuilder(connectionString);
        EnumConfiguration.Configure(builder);
        var dataSource = builder.Build();
        services.AddSingleton(dataSource);
        services.AddScoped<IDbConnectionFactory, PostgreSqlConnectionFactory>();
        //


        return services;
    }
}