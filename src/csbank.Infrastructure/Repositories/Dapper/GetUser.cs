using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Database.PostgreSQL;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;
using Microsoft.Extensions.Logging;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class ReadUserRepository(
    IDbConnectionFactory _db,
    ILogger<ReadUserRepository> logger
) : IReadUserRepository
{
    public async Task<UserDetailsDto>
    GetUserByIdAsync(Guid id)
    {
        using var connection = await _db.CreateConnectionAsync();

        try
        {
            string sql = ReadUserById.readUserQueryById;

            var data = await connection.QuerySingleAsync<UserDetailsDto>(sql, new { id });

            return data;
        }
        catch (Exception error)
        {
            logger.LogError(error, "Cannot read user data.");
            throw;
        }
    }
}