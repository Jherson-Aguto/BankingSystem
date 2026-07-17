using CSbank.Infrastructure.Database.Connections;
using CSbank.Infrastructure.Database.PostgreSQL;
using CSbank.Infrastructure.Mapper;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using Dapper;
using Microsoft.Extensions.Logging;

namespace CSbank.Infrastructure.Repositories.Dapper;

public class SaveUserDetailsRepository
(IDbConnectionFactory _db,
ILogger<SaveUserDetailsRepository> logger)
: ISaveUserDetailsRepository
{
    public async Task SaveCustomerDetailsAsync(CustomerDto customerDetails, PrivateInfoDto privateInformation)
    {
        var (connection, transaction) = await _db.CreateConnectionAsync();
        using (connection)

        await using (transaction)
            try
            {
                string query = SaveUserDetails.SaveCustomerDetailsAndPrivateInformation;

                var parameters = Map.ToParameters(privateInformation, customerDetails);

                Guid rowsAffected = await connection.QueryFirstAsync<Guid>(query, parameters, transaction);

                await transaction.CommitAsync();
            }
            catch (Exception error)
            {
                logger.LogError($"Cannot Save Customer Details Rolling Back Transaction...\n{error}");
                await transaction.RollbackAsync();
                throw;
            }

    }
}