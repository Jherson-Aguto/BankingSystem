using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Database.PostgreSQL;
using CSbank.Infrastructure.Mapper;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;
using Microsoft.Extensions.Logging;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveUserRepository
(IDbConnectionFactory _db,
ILogger<SaveUserRepository> logger)
: ISaveUserRepository
{
    public async Task DetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation)
    {
        using var connection = await _db.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        try
        {
            string query = SaveUser.DetailsAndPrivateInformation;

            var parameters = MapUser.ToParameters(privateInformation, customerDetails);

            Guid customerId =
                await connection.QuerySingleAsync<Guid>(
                    query,
                    parameters,
                    transaction);

            transaction.Commit();
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                "Cannot save customer details. Rolling back transaction.");

            transaction.Rollback();
            throw;
        }

    }
}