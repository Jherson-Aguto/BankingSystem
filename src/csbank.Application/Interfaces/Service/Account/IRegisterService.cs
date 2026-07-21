using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IRegisterAccountsService
{
    Task<Guid> DetailsAsync(AccountDto accountDto);
}