using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

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