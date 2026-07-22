using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Database.Queries;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Mapper;
using CSBank.Application.Models;
using Dapper;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveUserRepository(
    IDbConnectionFactory _db)
    : ISaveUserRepository
{
    public async Task DetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation)
    {
        using var connection = await _db.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        try
        {
            string query = SaveUser.DetailsAndPrivateInformation;

            var parameters = Map.ToParameters(privateInformation, customerDetails);

            Guid customerId =
                await connection.QuerySingleAsync<Guid>(
                    query,
                    parameters,
                    transaction);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }

    }
}