using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ISaveAccountsRepository
{
    Task<Guid> DetailsAsync(AccountDto accountDto);
    Task<Guid?> AccountTypeCreationAsync(
        Guid accountId,
        string accountNumber,
        bool? IsChecking = false);
}