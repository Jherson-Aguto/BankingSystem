using CSbank.Application.Mapper;
using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Database.Queries;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveAccountsRepository(
    HelperFunctions db)
    : ISaveAccountsRepository
{
    public async Task<Guid> DetailsAsync(AccountDto accountDto)
    {
        return await db.ExecuteTransactionAsync(
            async (connection, transaction) =>
            {
                return await connection.QuerySingleAsync<Guid>(
                    SaveAccount.Details,
                    MapAccount.ToParameters(accountDto),
                    transaction
                );
            }
        );
    }

    public async Task<Guid?> AccountTypeCreationAsync(
        Guid accountId,
        string accountNumber,
        bool? IsChecking = false)
    {
        return await db.ExecuteTransactionAsync(
            async (connection, transaction) =>
            {
                string sql = IsChecking switch
                {
                    true => SaveAccount.checking,
                    _ => SaveAccount.savings
                };

                return await connection
                    .QuerySingleAsync<Guid>(
                        sql,
                        new { accountId, accountNumber },
                        transaction);
            }
        );
    }
}