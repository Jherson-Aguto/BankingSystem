
namespace CSbank.Infrastructure.Database.Queries;

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
    WITH account AS (
        SELECT
            id,
            account_number
        FROM accounts.account_details
        WHERE
            id = @accountId AND
            account_number = @accountNumber
    ),
    checking AS (
        INSERT INTO accounts.checking_account(
            account_id
    )
        SELECT
            account.id
        FROM account
    )
    SELECT id AS AccountId FROM account;
    """;

    public const string savings =
    """
    WITH account AS (
        SELECT
            id,
            account_number
        FROM accounts.account_details
        WHERE
            id = @accountId AND
            account_number = @accountNumber 
    ),
    savings AS (
        INSERT INTO accounts.savings_account(
            account_id
    )
        SELECT
            account.id
        FROM account
    )
    SELECT id As AccountId FROM account;
    """;
}