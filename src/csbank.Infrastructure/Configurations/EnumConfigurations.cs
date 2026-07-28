

using CSbank.Domain.Entities;
using Npgsql;

namespace CSbank.Infrastructure.Configurations;

public static class EnumConfiguration
{
    public static void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<AccountTypes>("accounts.account_types");
        builder.MapEnum<AccountStatus>("accounts.account_status");
        builder.MapEnum<ModesOfPayment>("accounts.modes_of_payment");
    }
}