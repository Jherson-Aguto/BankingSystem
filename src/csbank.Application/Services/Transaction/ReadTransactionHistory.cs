using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class ReadTransactionHistory(
    IGetTransactionHistoryRepository getTransaction
) : IReadTransactionHistory
{
    public async Task<IEnumerable<TransactionDto?>?> ReadTransactionHistoryAsync(
       Guid accountid,
       int pageNumber
   )
    {
        const int pageSize = 10;

        int offSet = (pageNumber - 1) * pageSize;

        var results = await getTransaction.GetTransactionAsync(accountid, offSet, pageSize);

        if (!results!.Any())
            return null;

        return results;
    }
}