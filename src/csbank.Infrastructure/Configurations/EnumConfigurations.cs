

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
        builder.MapEnum<EntityNames>("audit.entity_names");
        builder.MapEnum<Actions>("audit.actions");
        builder.MapEnum<TransactionTypes>("transactions.transaction_types");
    }
}