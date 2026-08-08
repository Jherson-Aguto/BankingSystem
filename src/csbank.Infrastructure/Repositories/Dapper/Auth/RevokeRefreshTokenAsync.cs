using CSBank.Application.Interfaces.IRepositories;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class RevokeRefreshTokenRepository(
    HelperFactory db)
    : IRevokeRefreshTokenRepository
{
    public async Task RevokeRefreshTokenAsync(Guid userId)
    {
        await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                return await connection.ExecuteAsync(
                    RevokeRefreshTokenQuery.Revoke,
                    new
                    {
                        userId
                    },
                    transaction
                );
            }
        );
    }
}