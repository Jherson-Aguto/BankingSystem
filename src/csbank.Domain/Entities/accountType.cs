namespace CSbank.Domain.Entities;

public class CheckingAccount
{
    public Guid AccountId { get; private set; }
    public decimal OverdraftLimit { get; private set; }
    public ModesOfPayment? ModesOfPayment { get; private set; }
    public decimal? InterestRate { get; private set; }
    public decimal? Fees { get; private set; }
    public AccountDetails AccountDetails { get; private set; } = null!;

    private CheckingAccount() { }

    public CheckingAccount(
        Guid accountId,
        ModesOfPayment? modesOfPayment
    )
    {
        AccountId = accountId;
        OverdraftLimit = 0m;
        ModesOfPayment = modesOfPayment;
        InterestRate = 0m;
        Fees = 0m;
    }
}

public class SavingsAccount
{
    public Guid AccountId { get; private set; }
    public decimal WithdrawalUsage { get; private set; }
    public decimal? InterestRate { get; private set; }
    public decimal? Fees { get; private set; }
    public AccountDetails AccountDetails { get; private set; } = null!;

    private SavingsAccount() { }

    public SavingsAccount(
        Guid accountId
    )
    {
        AccountId = accountId;
        WithdrawalUsage = 0m;
        InterestRate = 0m;
        Fees = 0m;
    }
}