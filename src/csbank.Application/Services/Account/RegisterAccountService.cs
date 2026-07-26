using CSbank.Application.Mapper;
using CSbank.Domain.Services.Account;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Mapper;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterAccountsService(
    ISaveAccountsRepository saveAccounts,
    AccountDomainService domainService)
    : IRegisterAccountsService
{
    public async Task<AccountDto> DetailsAsync(RequestAccountDto requestAccountDto, AccountTypes accountType)
    {
        string accountNumber = domainService.GenerateAccountNumber(requestAccountDto.Currency);

        RequestAccountDto dto = MapAccount.ToParameters(requestAccountDto, accountNumber);

        return await saveAccounts.DetailsAsync(dto, accountType);
    }


}