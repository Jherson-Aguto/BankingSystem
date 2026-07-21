namespace CSBank.Application.Models;

public class AccountDto
{
    public Guid? Id { get; set; }
    public Guid CustomerId { get; set; }
    public string? AccountNumber { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
};

public record CheckingAccount
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
    public decimal OverdraftLimit { get; set; }
    public ModesOfPayment ModesOfPayment { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? Fees { get; set; }
};

public class SavingsAccount
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; }
    public int WithdrawalUsage { get; set; }
    public decimal InterestRate { get; set; }
    public decimal? Fees { get; set; }
};