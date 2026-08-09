using CSBank.Infrastructure.Database.Queries;
using CSBank.Infrastructure.Utils;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;

namespace CSBank.Infrastructure.Repositories.Dapper;

public class SaveUserRepository(
    HelperFactory db)
    : ISaveUserRepository
{
    public async Task<UserDetailsDto?> DetailsAsync(RequestUserDetailsDto requestUserDetailsDto, CancellationToken cancellationToken)
    {
        return await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                var command = new CommandDefinition(
                    commandText: SaveUser.DetailsAndPrivateInformation,
                    parameters: requestUserDetailsDto,
                    transaction: transaction,
                    commandTimeout: 30
                );

                return (await connection.QueryAsync<CustomerDto, PrivateInfoDto, UserDetailsDto>(
                        command,
                        (CustomerDto customerDto, PrivateInfoDto privateInfoDto)
                            => new UserDetailsDto(customerDto, privateInfoDto),
                        splitOn: "CustomerId"))
                    .SingleOrDefault();
            }
        );
    }
}