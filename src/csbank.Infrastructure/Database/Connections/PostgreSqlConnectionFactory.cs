using System.Data;
using CSbank.Infrastructure.Database.Connections;
using Npgsql;


public class PostgreSqlConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}