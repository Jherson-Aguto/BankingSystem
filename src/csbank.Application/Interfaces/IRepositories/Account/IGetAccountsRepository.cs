using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface IGetAccountsRepository
{
    Task<List<AccountDto?>?> GetAccountListAsync(
        Guid id,
        int offset,
        int pageSize,
        CancellationToken cancellationToken);
}