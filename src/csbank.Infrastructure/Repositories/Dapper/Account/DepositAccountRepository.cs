using CSbank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSbank.Infrastructure.Database.Queries;
using CSbank.Infrastructure.Utils;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class DepositRepository(HelperFactory db) : IDepositRepository
{
    public async Task<TransactionDto?> DepositAmount(
        RequestDepositDto requestDepositDto)
    {
        return await db.TransactionOperationAsync(
           async (connection, transaction) =>
           {
               return await connection.QuerySingleOrDefaultAsync<TransactionDto>(
                   DepositQuery.Deposit,
                   requestDepositDto,
                   transaction
                 );
           }
       );
    }
}