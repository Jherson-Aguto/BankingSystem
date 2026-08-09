using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class DepositRepository(HelperFactory db) : IDepositRepository
{
    public async Task<TransactionDto?> DepositAmount(
        RequestDepositDto requestDepositDto,
        CancellationToken cancellationToken)
    {
        return await db.TransactionOperationAsync(
           async (connection, transaction) =>
           {
               var command = new CommandDefinition(
                   commandText: DepositQuery.Deposit,
                   parameters: requestDepositDto,
                   transaction: transaction,
                   cancellationToken: cancellationToken,
                   commandTimeout: 60
               );

               return await connection.QuerySingleOrDefaultAsync<TransactionDto>(command);
           }
       );
    }
}