using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class SaveAccountsRepository(
    HelperFactory db)
    : ISaveAccountsRepository
{
    public async Task<AccountDto?> DetailsAsync(RequestAccountDto requestAccountDto, AccountTypes accountType)
    {
        return await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                string sql = accountType switch
                {
                    AccountTypes.Checking => SaveAccount.CheckingDetails,
                    AccountTypes.Savings => SaveAccount.SavingsDetails,
                    _ => throw new ArgumentOutOfRangeException(nameof(accountType))
                };

                return await connection.QuerySingleOrDefaultAsync<AccountDto>(
                    sql,
                    requestAccountDto,
                    transaction);
            }
        );
    }
}