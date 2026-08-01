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
    public async Task<UserDetailsDto?> DetailsAsync(RequestUserDetailsDto requestUserDetailsDto)
    {
        return await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                return (await connection
                    .QueryAsync<CustomerDto, PrivateInfoDto, UserDetailsDto>(
                         SaveUser.DetailsAndPrivateInformation,
                        (CustomerDto customerDto, PrivateInfoDto privateInfoDto)
                            => new UserDetailsDto(customerDto, privateInfoDto),
                        requestUserDetailsDto,
                         transaction,
                        splitOn: "CustomerId"))
                    .SingleOrDefault();
            }
        );
    }
}