using CSBank.Application.Interfaces.IRepositories;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class RevokeRefreshTokenRepository(
    HelperFactory db)
    : IRevokeRefreshTokenRepository
{
    public async Task RevokeRefreshTokenAsync(Guid userId, CancellationToken cancellationToken)
    {
        await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                var command = new CommandDefinition(
                    commandText: RevokeRefreshTokenQuery.Revoke,
                    parameters: new { userId },
                    transaction: transaction,
                    commandTimeout: 30
                );

                return await connection.ExecuteAsync(command);
            }
        );
    }
}