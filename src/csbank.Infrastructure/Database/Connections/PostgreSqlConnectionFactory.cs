using System.Data;
using CSbank.Infrastructure.Database.Connections;
using Npgsql;

public class PostgreSqlConnectionFactory(string connectionString) : IDbConnectionFactory
{
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        // Create NpgsqlConnection
        var connection = new NpgsqlConnection(connectionString);
        // Open it
        await connection.OpenAsync();
        // Return it
        return connection;
    }
}