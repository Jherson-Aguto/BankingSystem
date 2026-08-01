
using CSBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSBank.Infrastructure.Configurations;


public sealed class CustomerConfiguration :
    IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("customer_details", "users");

        builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Suffix).HasColumnName("suffix").HasMaxLength(100);
        builder.Property(x => x.RegistrationDate).HasColumnName("registration_date").HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.MiddleInitial).HasColumnName("middle_initial").HasMaxLength(1);

        builder
            .HasOne(x => x.PrivateInformation)
            .WithOne(x => x.Customer);

        builder
            .HasMany(x => x.AccountDetails)
            .WithOne(x => x.Customer);
    }
}

public sealed class PrivateInformationConfiguration
    : IEntityTypeConfiguration<PrivateInformation>
{
    public void Configure(EntityTypeBuilder<PrivateInformation> builder)
    {
        builder.HasKey(x => x.CustomerId);

        builder.ToTable("private_information", "users");

        builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(254).IsRequired();
        builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").HasMaxLength(100).IsRequired();
        builder.Property(x => x.City).HasColumnName("city").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Province).HasColumnName("province").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Country).HasColumnName("country").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Nationality).HasColumnName("nationality").HasMaxLength(100).IsRequired();
        builder.Property(x => x.BirthDate).HasColumnName("birth_date").HasColumnType("date").IsRequired();

        builder
            .HasOne(x => x.Customer)
            .WithOne(x => x.PrivateInformation)
            .HasForeignKey<PrivateInformation>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}