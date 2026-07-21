using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterAccountsService(
    ISaveAccountsRepository saveAccounts)
    : IRegisterAccountsService
{
    public async Task DetailsAsync(AccountDto accountDto)
    {
        Console.WriteLine($"Account Status Service: {accountDto.AccountStatus}");
        await saveAccounts.DetailsAsync(accountDto);
    }
}