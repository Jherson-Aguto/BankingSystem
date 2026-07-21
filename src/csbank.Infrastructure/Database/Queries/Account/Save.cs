public sealed class SaveAccount
{
    public const string Details =
    """
    INSERT INTO accounts.account_details(
        customer_id,
        account_number,
        currency,
        account_status    
    )
    VALUES(
        @customerId,
        @accountNumber,
        @currency,
        @accountStatus::accounts.account_status
    )
    RETURNING id AS Id;
    """;
}