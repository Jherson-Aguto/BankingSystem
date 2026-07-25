
namespace CSbank.Infrastructure.Database.Queries;

public sealed class SaveAccount
{
    public const string Details =
    """
    WITH account AS (
        INSERT INTO 
            accounts.account_details(
                customer_id,
                account_number,
                currency,
                account_status    
    )
        VALUES(
            @customerId,
            @accountNumber,
            @currency,
            @accountStatus::accounts.account_status)
        RETURNING
            id,
            customer_id
    ),
    recorded_audit AS (
        INSERT INTO 
            audit.audit_logs (
                entity_name,
                entity_id,
                action,
                performed_by
    )
        SELECT
            'Account',
            a.id,
            'Created',
            a.customer_id
        FROM account AS a
    )
    SELECT 
        id AS Id FROM account;
    """;

    public const string checking =
    """
    WITH account AS (
        SELECT
            id,
            customer_id,
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
            account.id FROM account
    ),
    recorded_audit AS (
        INSERT INTO 
            audit.audit_logs(
                entity_name,
                entity_id,
                action,
                performed_by
        )
        SELECT
            'CheckingAccount',
            a.id,
            'Created',
            a.customer_id
        FROM 
            account AS a
    )
    SELECT 
        a.id AS AccountId FROM account AS a;
    """;

    public const string savings =
    """
    WITH account AS (
        SELECT
            id,
            customer_id,
            account_number
        FROM 
            accounts.account_details
        WHERE
            id = @accountId AND
            account_number = @accountNumber 
    ),
    savings AS (
        INSERT INTO 
            accounts.savings_account(
                account_id
    )
        SELECT
            a.id
        FROM 
            account AS a
    ),
    recorded_audit AS (
        INSERT INTO 
            audit.audit_logs (
                entity_name,
                entity_id,
                action,
                performed_by
    )
        SELECT
            'SavingsAccount',
            a.id,
            'Created',
            a.customer_id
        FROM account AS a
    )
    SELECT 
        a.id As AccountId FROM account AS a;
    """;
}