using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IReadAccountsServices
{
    Task<List<AccountDto?>?> AccountDetails(Guid id, int pageNumber, CancellationToken cancellationToken);
}