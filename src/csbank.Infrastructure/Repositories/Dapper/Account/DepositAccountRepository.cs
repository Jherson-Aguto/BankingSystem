using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Models;
using CSbank.Infrastructure.Database.Queries;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class DepositRepository(HelperFunctions db) : IDepositRepository
{
    public async Task<DepositRepositoryOutputDto?> DepositBalanceAsync(DepositDto depositDto, string? referenceNumber)
    {
        return await db.ExecuteTransactionAsync(
            async (connection, transaction) =>
            {
                string sql = depositDto.IsChecking switch
                {
                    true => DepositQuery.DepositChecking,
                    _ => DepositQuery.DepositSavings
                };

                return await connection.QuerySingleOrDefaultAsync<DepositRepositoryOutputDto>(
                    sql,
                    new
                    {
                        depositDto.AccountId,
                        depositDto.AccountNumber,
                        depositDto.DepositValue,
                        depositDto.Description,
                        referenceNumber
                    },
                    transaction
                );
            }
        );
    }
}