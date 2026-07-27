using CSbank.Infrastructure.Database.Queries;
using CSbank.Infrastructure.Utils;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Mapper;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveUserRepository(
    HelperFactory db)
    : ISaveUserRepository
{
    public async Task<UserDetailsDto?> DetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation)
    {
        return await db.TransactionOperationAsync(
            async (connection, transaction) =>
            {
                var parameters = Map.ToParameters(privateInformation, customerDetails);

                return (await connection.QueryAsync<CustomerDto, PrivateInfoDto, UserDetailsDto>(
                    SaveUser.DetailsAndPrivateInformation,
                    (CustomerDto customerDto, PrivateInfoDto privateInfoDto)
                     => new UserDetailsDto(customerDto, privateInfoDto),
                    parameters,
                    transaction,
                    splitOn: "CustomerId")).SingleOrDefault();
            }
        );
    }
}