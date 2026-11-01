using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IReadTransactionHistory
{
    Task<IEnumerable<TransactionDto?>?> ReadTransactionHistoryAsync(
        Guid accountid,
        Guid customerId,
        int pageNumber
    );
}