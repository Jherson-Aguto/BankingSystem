using System.Data;
using CSbank.Infrastructure.Database.Connections;

public class HelperFunctions(
    IDbConnectionFactory db)
{
    public async Task<T> ExecuteTransactionAsync<T>(
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

    public async Task<T> ExecuteAsync<T>(
        Func<IDbConnection, Task<T>> operation)
    {
        using var connection = await db.CreateConnectionAsync();

        return await operation(connection);
    }
}