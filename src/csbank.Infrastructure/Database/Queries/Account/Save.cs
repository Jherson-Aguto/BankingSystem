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

    public const string checking =
    """
    INSERT INTO accounts.checking_account(
        account_id
    )
    VALUES(
        @accountId
    );
    """;

    public const string savings =
    """
    INSERT INTO accounts.savings_account(
        account_id
    )
    VALUES(
        @accountId
    );
    """;
}