using System.Security.Cryptography;
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

        await db.OperationAsync(
           async (connection) =>
           {
               return await connection.ExecuteAsync(
                   SaveRefreshTokenQuery.save,
                   new
                   {
                       refreshTokenHash,
                       userId
                   }
                );
           }
       );
    }
}