using CSBank.Infrastructure.Configurations;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Infrastructure.Database.Connections;
using CSBank.Infrastructure.Repositories.Dapper;
using CSBank.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using CSBank.Infrastructure.Repositories.EntityFrameworkCore;
using CSBank.Application.Interfaces.Services;

namespace CSBank.Infrastructure.DI;

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
        services.AddScoped<IUpdateUserRepository, UpdateUserRepository>();
        services.AddScoped<IGetTransactionHistoryRepository, GetTransactionHistoryRepository>();
        services.AddScoped<IPasswordService, PasswordService>();

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