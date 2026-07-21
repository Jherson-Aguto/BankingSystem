using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Mapper;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;
using Microsoft.Extensions.Logging;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveAccountsRepository(
    IDbConnectionFactory db,
    ILogger<SaveAccountsRepository> logger)
    : ISaveAccountsRepository
{
    public async Task DetailsAsync(AccountDto accountDto)
    {
        string sql = SaveAccount.Details;

        using var connection = await db.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        try
        {
            Console.WriteLine($"Account Status Repository Before mapping: {accountDto.AccountStatus}");
            var parameters = MapAccount.ToParameters(accountDto);
            await connection.ExecuteAsync(sql, parameters);
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            logger.LogError("Cannot save account details");
            throw;
        }
    }
}