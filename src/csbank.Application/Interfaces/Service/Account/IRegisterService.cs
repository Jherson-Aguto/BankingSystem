using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IRegisterAccountsService
{
    Task<AccountDto> DetailsAsync(RequestAccountDto requestAccountDto, AccountTypes accountType);
}