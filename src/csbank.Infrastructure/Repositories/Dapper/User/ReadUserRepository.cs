using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Database.Queries;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class ReadUserRepository(
    HelperFunctions db)
    : IReadUserRepository
{
    public async Task<UserDetailsDto> ByIdAsync(Guid id)
    {
        return await db.ExecuteAsync(
            async (connection) =>
            {
                var data = (await connection.QueryAsync<
                        CustomerDto,
                        PrivateInfoDto,
                        UserDetailsDto>
                            (ReadUser.ById,
                            (CustomerDto, PrivateInfoDto) =>
                                new UserDetailsDto(CustomerDto, PrivateInfoDto),
                            new { id },
                            splitOn: "CustomerId"))
                        .SingleOrDefault();

                return data!;
            }
        );
    }
}
