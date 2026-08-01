using CSBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSBank.Infrastructure.Database.Connections;

public class AppDbContext : DbContext
{

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<PrivateInformation> PrivateInformation => Set<PrivateInformation>();
                public DbSet<AccountDetails> AccountDetails => Set<AccountDetails>();
    public DbSet<CheckingAccount> CheckingAccounts => Set<CheckingAccount>();
    public DbSet<SavingsAccount> SavingsAccounts => Set<SavingsAccount>();
    public DbSet<TransactionHistory> TransactionHistories => Set<TransactionHistory>();
    public DbSet<AuditLogs> AuditLogs => Set<AuditLogs>();

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