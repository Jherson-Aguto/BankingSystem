using System.Data;

namespace CSBank.Infrastructure.Database.Connections;

public interface IDbConnectionFactory
{
   Task<IDbConnection> CreateConnectionAsync();
}