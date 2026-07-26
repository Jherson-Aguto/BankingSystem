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
    public async Task DetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation)
    {
        await db.TransactionOperationAsync(
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