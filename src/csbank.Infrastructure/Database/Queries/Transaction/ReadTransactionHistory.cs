namespace CSBank.Infrastructure.Database.Queries;

public sealed class ReadTransactionHistory
{
    public const string QueryOffSet =
    """
    SELECT
        id,
        account_id AS AccountId,
        transaction_type::transactions.transaction_types::text AS TransactionType,
        amount,
        balance_before AS BalanceBefore,
        balance_after As BalanceAfter,
        reference_number AS ReferenceNumber,
        description,
        created_at AS CreatedAt
    FROM transactions.transaction_history
    WHERE account_id = @AccountId
    ORDER BY created_at DESC
    OFFSET @offSet
    LIMIT @pageSize
    """;

    public const string Query =
   """
    SELECT
        id,
        account_id AS AccountId,
        transaction_type::transactions.transaction_types AS TransactionType,
        amount,
        balance_before AS BalanceBefore,
        balance_after As BalanceAfter,
        reference_number AS ReferenceNumber,
        description,
        created_at AS CreatedAt
    FROM transactions.transaction_history
    WHERE account_id = @AccountId
    AND created_at > 
    LIMIT 10
    """;
}