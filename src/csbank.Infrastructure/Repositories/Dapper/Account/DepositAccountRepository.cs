using CSbank.Application.Interfaces.IRepositories;
using CSbank.Application.Models;
using CSbank.Infrastructure.Database.Connections;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class DepositRepository(IDbConnectionFactory db) : IDepositRepository
{
    public async Task<decimal> DepositBalance(DepositDto depositDto)
    {
        using var connection = await db.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        try
        {


            transaction.Commit();
            return 1;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}