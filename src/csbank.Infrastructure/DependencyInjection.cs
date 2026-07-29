using System.Data;
using CSbank.Application.Interfaces.IRepositories;
using CSbank.Infrastructure.Configurations;
using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Repositories.Dapper;
using CSbank.Infrastructure.Utils;
using CSBank.Application.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace CSbank.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
    (this IServiceCollection services, IConfiguration configuration)
    {
        //infra
        services.AddScoped<ISaveUserRepository, SaveUserRepository>();
        services.AddScoped<IReadUserRepository, ReadUserRepository>();
        services.AddScoped<ISaveAccountsRepository, SaveAccountsRepository>();
        services.AddScoped<IDepositRepository, DepositRepository>();
        services.AddScoped<ITransferFundRepository, TransferFundRepository>();

        //helper
        services.AddScoped<HelperFactory>();

        //connection
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var builder = new NpgsqlDataSourceBuilder(connectionString);
        EnumConfiguration.Configure(builder);
        var dataSource = builder.Build();
        services.AddSingleton(dataSource);
        services.AddScoped<IDbConnectionFactory, PostgreSqlConnectionFactory>();

        //EF Core
        services.AddDbContext<AppDbContext>(
            option => option.UseNpgsql(connectionString)
        );


        return services;
    }
}