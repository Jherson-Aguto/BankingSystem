namespace CSBank.Domain.Entities;

public class TransactionHistory
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public TransactionTypes TransactionType { get; private set; }
    public decimal Amount { get; private set; }
    public decimal BalanceBefore { get; private set; }
    public decimal BalanceAfter { get; private set; }
    public string ReferenceNumber { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public AccountDetails AccountDetails { get; private set; } = null!;

    private TransactionHistory() { }

    public TransactionHistory(
        Guid accountId,
        TransactionTypes transactionType,
        decimal amount,
        decimal balanceBefore,
        decimal balanceAfter,
        string referenceNumber,
        string? description
    )
    {
        AccountId = accountId;
        TransactionType = transactionType;
        Amount = amount;
        BalanceBefore = balanceBefore;
        BalanceAfter = balanceAfter;
        ReferenceNumber = referenceNumber;
        Description = description ?? "No description";
    }
}