using CSBank.Application.Interfaces.IRepositories;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class SaveRefreshTokenRepository(
    HelperFactory db
) : ISaveRefreshTokenRepository
{
    public async Task SaveRefreshTokenAsync(
        string refreshTokenHash,
        Guid userId,
        CancellationToken cancellationToken)
    {
        await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {

                var command = new CommandDefinition(
                    commandText: SaveRefreshTokenQuery.save,
                    parameters:
                    new
                    {
                        refreshTokenHash,
                        userId
                    },
                    transaction: transaction,
                    cancellationToken: cancellationToken,
                    commandTimeout: 30
                );

                return await connection.QueryAsync<int>(command);
            }
        );
    }
}