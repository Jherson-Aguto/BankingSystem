using System.Collections;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class GetTransactionHistoryRepository(
    HelperFactory db
)
    : IGetTransactionHistoryRepository
{
    public async Task<IEnumerable<TransactionDto?>?> GetTransactionAsync(Guid accountId, int offSet, int pageSize)
    {
        return await db.OperationAsync(
            async (connection) =>
            {
                return await connection.QueryAsync<TransactionDto?>(
                      ReadTransactionHistory.QueryOffSet,
                      new
                      {
                          accountId,
                          offSet,
                          pageSize
                      }
                  );
            }
        );
    }
}