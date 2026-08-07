using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface IGetTransactionHistoryRepository
{
    Task<IEnumerable<TransactionDto?>?> GetTransactionAsync(Guid accountId, int offSet, int pageNumber);
}