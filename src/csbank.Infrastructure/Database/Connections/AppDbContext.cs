using CSbank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSbank.Infrastructure.Database.Connections;

public class AppDbContext : DbContext
{

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<PrivateInformation> PrivateInformation => Set<PrivateInformation>();

    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
    }
}