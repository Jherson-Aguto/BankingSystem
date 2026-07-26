using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Models;
using CSbank.Infrastructure.Database.Queries;
using CSbank.Infrastructure.Utils;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class DepositRepository(HelperFactory db) : IDepositRepository
{
    public async Task<TransactionDto> DepositAmount(
        RequestDepositDto requestDepositDto,
        AccountTypes accountType)
    {
        return await db.TransactionOperationAsync(
           async (connection, transaction) =>
           {
               return await connection.QuerySingleAsync<TransactionDto>(
                   DepositQuery.Deposit,
                   requestDepositDto,
                   transaction
                 );
           }
       );
    }
}