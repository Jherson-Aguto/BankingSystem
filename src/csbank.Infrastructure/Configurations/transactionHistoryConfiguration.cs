using CSBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSBank.Infrastructure.Configurations;

public class TransactionHistoryConfiguration
    : IEntityTypeConfiguration<TransactionHistory>
{
    public void Configure(EntityTypeBuilder<TransactionHistory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("transaction_history", "transactions");

        builder.Property(x => x.Id).HasColumnName("id").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();
        builder.Property(x => x.TransactionType).HasColumnName("transaction_type")
            .HasColumnType("transactions.transaction_types").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").IsRequired();
        builder.Property(x => x.BalanceBefore).HasColumnName("balance_before").IsRequired();
        builder.Property(x => x.BalanceAfter).HasColumnName("balance_after").IsRequired();
        builder.Property(x => x.ReferenceNumber).HasColumnName("reference_number").HasMaxLength(254).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at")
            .HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();

        builder
            .HasOne(x => x.AccountDetails)
            .WithMany(x => x.TransactionHistory)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}