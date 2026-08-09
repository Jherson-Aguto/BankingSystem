namespace CSBank.Infrastructure.Database.Queries;

public sealed class ReadTransactionHistory
{
    public const string QueryOffSet =
    """
    SELECT
        th.id,
        th.account_id AS AccountId,
        th.transaction_type::transactions.transaction_types::text AS TransactionType,
        th.amount,
        th.balance_before AS BalanceBefore,
        th.balance_after As BalanceAfter,
        th.reference_number AS ReferenceNumber,
        th.description,
        th.created_at AS CreatedAt
    FROM transactions.transaction_history th
    JOIN users.user_credentials uc
    WHERE account_id = @AccountId
    AND uc.user_id = @customerId
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