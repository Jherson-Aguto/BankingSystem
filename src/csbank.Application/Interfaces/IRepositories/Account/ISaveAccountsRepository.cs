using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;


public interface ISaveAccountsRepository
{
    Task DetailsAsync(AccountDto accountDto);
}