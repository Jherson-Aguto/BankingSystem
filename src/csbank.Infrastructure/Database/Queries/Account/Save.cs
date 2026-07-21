public sealed class SaveAccount
{
    public const string Details =
    """
    INSERT INTO accounts.account_details(
        customer_id,
        account_number,
        currency,
        created_at,
        account_status    
    )
    VALUES(
        @customerId,
        @accountNumber,
        @currency,
        @createdAt,
        @accountStatus::accounts.account_status
    )
    RETURNING id AS Id;
    """;
}