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
    ByIdAsync(Guid id)
    {
        using var connection = await _db.CreateConnectionAsync();

        try
        {
            string sql = ReadUser.ById;

            var data =
            (
                await connection.QueryAsync<
                        CustomerDto,
                        PrivateInfoDto,
                        UserDetailsDto>
                            (sql,
                            (CustomerDto, PrivateInfoDto) =>
                                new UserDetailsDto(CustomerDto, PrivateInfoDto),
                            new { id },
                            splitOn: "CustomerId")
                ).SingleOrDefault();

            return data!;
        }
        catch (Exception error)
        {
            logger.LogError(error, "Cannot read user data.");
            throw;
        }
    }
}