using System.Data;
using Npgsql;

namespace CSBank.Infrastructure.Database.Connections;

public class PostgreSqlConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}