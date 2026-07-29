using CSbank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSbank.Infrastructure.Configurations;

public sealed class AccountDetailsConfiguration
    : IEntityTypeConfiguration<AccountDetails>
{
    public void Configure(EntityTypeBuilder<AccountDetails> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("account_details", "accounts");

        builder.Property(x => x.CustomerId).HasColumnName("customer_id");
        builder.Property(x => x.AccountNumber).HasColumnName("account_number").HasMaxLength(100).IsRequired();
        builder.Property(x => x.AccountType).HasColumnType("accounts.account_types").HasColumnName("account_type");
        builder.Property(x => x.Currency).HasColumnName("currency").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Balance).HasColumnName("balance").HasDefaultValue(0m).IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
        builder.Property(x => x.AccountStatus).HasColumnName("account_status").HasColumnType("accounts.account_status").IsRequired();


        builder
            .HasOne(x => x.Customer)
            .WithMany(x => x.AccountDetails)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.CheckingAccount)
            .WithOne(x => x.AccountDetails);

        builder
            .HasOne(x => x.SavingsAccount)
            .WithOne(x => x.AccountDetails);

        builder
            .HasOne(x => x.TransactionHistory)
            .WithOne(x => x.AccountDetails);
    }
}