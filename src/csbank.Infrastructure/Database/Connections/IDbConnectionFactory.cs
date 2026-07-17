using System.Data;
using Npgsql;

namespace CSbank.Infrastructure.Database.Connections;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}