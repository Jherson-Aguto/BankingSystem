using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Mapper;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;
using Microsoft.Extensions.Logging;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveAccountsRepository(
    IDbConnectionFactory db)
    : ISaveAccountsRepository
{
    public async Task<Guid> DetailsAsync(AccountDto accountDto)
    {
        string sql = SaveAccount.Details;

        using var connection = await db.CreateConnectionAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            var parameters = MapAccount.ToParameters(accountDto);

            Guid id = await connection.QuerySingleAsync<Guid>(sql, parameters, transaction);

            transaction.Commit();

            return id;
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }
}