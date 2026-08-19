using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class ReadAccountsServices(IGetAccountsRepository getAccounts) : IReadAccountsServices
{
    public async Task<List<AccountDto?>?> AccountDetails(
        Guid id,
        int pageNumber,
        CancellationToken cancellationToken)
    {
        const int pageSize = 10;

        int offSet = (pageNumber - 1) * pageSize;

        List<AccountDto?>? results = await getAccounts.GetAccountListAsync(
            id,
            offSet,
            pageSize,
            cancellationToken);

        if (results is null)
            return null;

        return results;
    }
}