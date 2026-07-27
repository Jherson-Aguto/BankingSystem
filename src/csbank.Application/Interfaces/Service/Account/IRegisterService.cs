using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.Services;

public interface IRegisterAccountsService
{
    Task<AccountDto?> DetailsAsync(Guid customerId, string currency, AccountTypes accountType);
}