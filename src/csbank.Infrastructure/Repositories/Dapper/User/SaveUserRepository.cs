using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Database.Queries;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Mapper;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveUserRepository(
    HelperFunctions db)
    : ISaveUserRepository
{
    public async Task DetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation)
    {
        await db.ExecuteTransactionAsync(
           async (connection, transaction) =>
           {
               var parameters = Map.ToParameters(privateInformation, customerDetails);

               return await connection.QuerySingleAsync<Guid>(
                   SaveUser.DetailsAndPrivateInformation,
                   parameters,
                   transaction);
           }
       );
    }
}