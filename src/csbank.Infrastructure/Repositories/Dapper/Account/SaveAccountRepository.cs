using CSbank.Application.Mapper;
using CSbank.Infrastructure.Database.Queries;
using CSbank.Infrastructure.Utils;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

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