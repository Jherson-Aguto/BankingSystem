using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Models;
using CSbank.Infrastructure.Database.Queries;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class DepositRepository(HelperFunctions db) : IDepositRepository
{
    public async Task<DepositOutputDto> DepositBalanceAsync(DepositDto depositDto)
    {
        return await db.ExecuteTransactionAsync(
            async (connection, transaction) =>
            {
                string sql = depositDto.IsChecking switch
                {
                    true => DepositQuery.DepositChecking,
                    _ => DepositQuery.DepositSavings
                };

                return await connection.QuerySingleAsync<DepositOutputDto>(
                    sql,
                    new
                    {
                        depositDto.AccountId,
                        depositDto.AccountNumber,
                        depositDto.DepositValue
                    },
                    transaction
                );
            }
        );
    }
}