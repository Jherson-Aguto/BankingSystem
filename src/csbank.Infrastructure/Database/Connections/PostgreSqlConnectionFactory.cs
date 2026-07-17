using System.Data;
using CSbank.Infrastructure.Database.Connections;
using Npgsql;

public class PostgreSqlConnectionFactory(string connectionString) : IDbConnectionFactory
{
    public async Task<(IDbConnection connection, NpgsqlTransaction transaction)> CreateConnectionAsync()
    {
        // Create NpgsqlConnection
        var connection = new NpgsqlConnection(connectionString);
        // Open it
        await connection.OpenAsync();

        var transaction = await connection.BeginTransactionAsync();
        // Return it
        return (connection, transaction);
    }
}