using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class GetAccountsRepository(HelperFactory db) : IGetAccountsRepository
{
    public async Task<List<AccountDto?>?> GetAccountListAsync(
        Guid id,
        int offset,
        int pageSize,
        CancellationToken cancellationToken)
    {
        return await db.OperationAsync(
           async (connection) =>
           {
               var command = new CommandDefinition(
                   commandText: GetListQuery.AccountsQuery,
                   parameters: new { id, offset, pageSize },
                   commandTimeout: 30,
                   cancellationToken: cancellationToken
               );

               var results = await connection.QueryAsync<AccountDto?>(
                   command
               );

               if (results is null || !results.Any())
                   return null;

               return results.ToList();
           }
        );
    }
}