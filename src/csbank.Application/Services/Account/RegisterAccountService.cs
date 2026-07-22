using CSbank.Domain.Services.Account;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterAccountsService(
    ISaveAccountsRepository saveAccounts,
    AccountDomainService domainService)
    : IRegisterAccountsService
{
    public async Task<Guid> DetailsAsync(AccountDto accountDto)
    {
        string accountNumber = domainService.GenerateAccountNumber(accountDto.Currency);

        AccountDto dto = new AccountDto
        {
            CustomerId = accountDto.CustomerId,
            AccountNumber = accountNumber,
            Currency = accountDto.Currency,
            CreatedAt = accountDto.CreatedAt,
            AccountStatus = accountDto.AccountStatus
        };

        return await saveAccounts.DetailsAsync(dto);
    }

    public async Task<Guid?> AccountTypeCreationAsync(
        Guid accountId,
        string accountNumber,
        bool? IsChecking = false)
    {
        return await saveAccounts.AccountTypeCreationAsync(accountId, accountNumber, IsChecking);
    }

}