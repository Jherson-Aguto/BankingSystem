using CSbank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSbank.Infrastructure.Configurations;

public sealed class CheckingAccountConfiguration
    : IEntityTypeConfiguration<CheckingAccount>
{
    public void Configure(EntityTypeBuilder<CheckingAccount> builder)
    {
        
    }
}