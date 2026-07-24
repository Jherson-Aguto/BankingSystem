using CSBank.Application.Models;
using Npgsql;

namespace CSbank.Infrastructure.Configurations;

public static class EnumConfiguration
{
    public static void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<AccountStatus>("accounts.account_status");

        builder.MapEnum<ModesOfPayment>("accounts.modes_of_payment");

        builder.MapEnum<TransactionTypes>("transactions.transaction_types");
    }
}