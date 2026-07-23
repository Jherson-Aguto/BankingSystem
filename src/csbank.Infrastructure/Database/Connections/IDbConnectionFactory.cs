using System.Data;

namespace CSbank.Infrastructure.Database.Connections;

public interface IDbConnectionFactory
{
   Task<IDbConnection> CreateConnectionAsync();
}