
namespace CSbank.Domain.Entities;

public class AccountDetails
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public string AccountNumber { get; private set; } = string.Empty;
    public AccountTypes AccountType { get; private set; }
    public string Currency { get; private set; } = string.Empty;
    public decimal Balance { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public AccountStatus AccountStatus { get; private set; }
    public Customer Customer { get; private set; } = null!;
    public CheckingAccount CheckingAccount { get; private set; } = null!;
    public SavingsAccount SavingsAccount { get; private set; } = null!;

    private AccountDetails() { }

    public AccountDetails(
        Guid customerId,
        string accountNumber,
        AccountTypes accountTypes,
        string currency
    )
    {
        CustomerId = customerId;
        AccountNumber = accountNumber;
        AccountType = accountTypes;
        Currency = currency;
        Balance = 0m;
        AccountStatus = AccountStatus.Active;
    }

    public bool Deposit(decimal depositAmount)
    {
        if (depositAmount > 0 && AccountStatus == AccountStatus.Active)
        {
            Balance += depositAmount;
            return true;
        }
        else return false;
    }

    public bool Deactivate()
    {
        if (AccountStatus == AccountStatus.Active)
        {
            AccountStatus = AccountStatus.Frozen;
            return true;
        }
        else return false;
    }

    public bool Activate()
    {
        if (AccountStatus == AccountStatus.Frozen)
        {
            AccountStatus = AccountStatus.Active;
            return true;
        }
        else return false;
    }

    public bool TransferOut(decimal transferAmount)
    {
        if (Balance >= transferAmount && AccountStatus == AccountStatus.Active)
        {
            Balance -= transferAmount;
            return true;
        }
        else return false;
    }

    public bool TransferIn(decimal transferAmount)
    {
        if (transferAmount > 0 && AccountStatus == AccountStatus.Active)
        {
            Balance += transferAmount;
            return true;
        }
        else
            return false;
    }

}