using CSBank.Application.Interfaces.IRepositories;
using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class SaveRefreshTokenRepository(
    HelperFactory db
) : ISaveRefreshTokenRepository
{
    public async Task SaveRefreshTokenAsync(string refreshTokenHash, Guid userId)
    {
        await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {

                return await connection.QueryAsync<int>(
                    SaveRefreshTokenQuery.save,
                    new
                    {
                        refreshTokenHash,
                        userId
                    },
                    transaction
                );
            }
        );
    }
}