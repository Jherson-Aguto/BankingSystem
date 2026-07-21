using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class RegisterAccountsService(
    ISaveAccountsRepository saveAccounts)
    : IRegisterAccountsService
{
    public async Task<Guid> DetailsAsync(AccountDto accountDto)
    {
        return await saveAccounts.DetailsAsync(accountDto);
    }
}