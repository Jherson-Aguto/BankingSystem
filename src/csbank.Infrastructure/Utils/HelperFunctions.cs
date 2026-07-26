using System.Data;
using CSbank.Infrastructure.Database.Connections;

namespace CSbank.Infrastructure.Utils;

public class HelperFactory(IDbConnectionFactory db)
{
    public async Task<T> TransactionOperationAsync<T>(
        Func<IDbConnection, IDbTransaction, Task<T>> operation)
    {
        using var connection = await db.CreateConnectionAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            T result = await operation(connection, transaction);

            transaction.Commit();

            return result;
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }

    public async Task<T> OperationAsync<T>(
        Func<IDbConnection, Task<T>> operation)
    {
        using var connection = await db.CreateConnectionAsync();

        T result = await operation(connection);

        return result;
    }
}