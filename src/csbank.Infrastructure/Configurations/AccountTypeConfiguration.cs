using CSbank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSbank.Infrastructure.Configurations;

public sealed class CheckingAccountConfiguration
    : IEntityTypeConfiguration<CheckingAccount>
{
    public void Configure(EntityTypeBuilder<CheckingAccount> builder)
    {
        builder.HasKey(x => x.AccountId);

        builder.ToTable("checking_account", "accounts");

        builder.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();
        builder.Property(x => x.OverdraftLimit).HasColumnName("overdraft_limit").HasDefaultValue(0m).IsRequired();
        builder.Property(x => x.ModesOfPayment).HasColumnName("modes_of_payment")
            .HasColumnType("accounts.modes_of_payment").HasDefaultValueSql("'Online'::accounts.modes_of_payment").IsRequired();
        builder.Property(x => x.InterestRate).HasColumnName("interest_rate");
        builder.Property(x => x.Fees).HasColumnName("fees");

        builder
            .HasOne(x => x.AccountDetails)
            .WithOne(x => x.CheckingAccount)
            .HasForeignKey<CheckingAccount>(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class SavingsAccountConfiguration
    : IEntityTypeConfiguration<SavingsAccount>
{
    public void Configure(EntityTypeBuilder<SavingsAccount> builder)
    {
        builder.HasKey(x => x.AccountId);

        builder.ToTable("savings_account", "accounts");

        builder.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();
        builder.Property(x => x.WithdrawalUsage).HasColumnName("withdrawal_usage").HasDefaultValue(0m).IsRequired();
        builder.Property(x => x.InterestRate).HasColumnName("interest_rate");
        builder.Property(x => x.Fees).HasColumnName("fees");

        builder
            .HasOne(x => x.AccountDetails)
            .WithOne(x => x.SavingsAccount)
            .HasForeignKey<SavingsAccount>(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}