using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;


public interface ISaveAccountsRepository
{
    Task<Guid> DetailsAsync(AccountDto accountDto);
}