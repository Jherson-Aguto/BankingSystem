using CSBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSBank.Infrastructure.Configurations;

public class AuditLogsConfiguration
    : IEntityTypeConfiguration<AuditLogs>
{
    public void Configure(EntityTypeBuilder<AuditLogs> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("audit_logs", "audit");

        builder.Property(x => x.EntityName).HasColumnName("entity_name").HasColumnType("audit.entity_name").IsRequired();
        builder.Property(x => x.EntityId).HasColumnName("entity_id");
        builder.Property(x => x.Action).HasColumnName("action").IsRequired();
        builder.Property(x => x.PerformedBy).HasColumnName("performed_by").IsRequired();
        builder.Property(x => x.PerformedAt).HasColumnName("performed_at")
            .HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
        builder.Property(x => x.OldValues).HasColumnName("old_values").HasColumnType("jsonb");
        builder.Property(x => x.NewValues).HasColumnName("new_values").HasColumnType("jsonb");
        builder.Property(x => x.IpAddress).HasColumnName("ip_address").HasColumnType("inet").HasDefaultValueSql("inet_client_addr()");
        builder.Property(x => x.UserAgent).HasColumnName("user_agent").HasMaxLength(254);

    }
}