using CSbank.Application.Mapper;
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
    public async Task<AccountDto?> DetailsAsync(Guid customerId, string currency, AccountTypes accountType)
    {
        string accountNumber = domainService.GenerateAccountNumber(currency);

        var dto = MapAccount.ToParameters(customerId, currency, accountNumber);

        return await saveAccounts.DetailsAsync(dto, accountType);
    }


}