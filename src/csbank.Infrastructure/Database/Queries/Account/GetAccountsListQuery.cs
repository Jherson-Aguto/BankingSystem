namespace CSBank.Infrastructure.Database.Queries;

public sealed class GetListQuery
{
    public const string AccountsQuery =
    """
    SELECT 
        id,
        customer_id AS CustomerId,
        account_number AS AccountNumber,
        account_type::text AS AccountType,
        currency,
        balance,
        created_at AS CreatedAt,
        account_status::text AS AccountStatus
    FROM accounts.account_details
    WHERE customer_id = @id
    OFFSET @offset
    LIMIT @pageSize
    """;
}