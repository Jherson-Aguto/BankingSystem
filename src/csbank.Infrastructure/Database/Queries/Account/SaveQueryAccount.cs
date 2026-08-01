
namespace CSBank.Infrastructure.Database.Queries;

public sealed class SaveAccount
{
    public const string SavingsDetails =
    """
    WITH account AS (
        INSERT INTO 
            accounts.account_details(
                customer_id,
                account_number,
                account_type,
                currency,
                account_status    
            )
        SELECT
            @CustomerId,
            @AccountNumber,
            'Savings',
            @Currency,
            'Active'
        WHERE EXISTS(
            SELECT 1 FROM users.customer_details WHERE id = @CustomerId
        )
        RETURNING
            id,
            customer_id,
            account_number,
            account_type,
            currency,
            balance,
            created_at,
            account_status
    ),
    savings AS (
        INSERT INTO accounts.savings_account(
            account_id
        )
        SELECT
            a.id
        FROM account AS a
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
        WHERE
            a.id IS NOT NULL
    )
    SELECT 
        a.id,
        a.customer_id AS CustomerId,
        a.account_number AS AccountNumber,
        a.account_type::text AS AccountType,
        a.currency,
        a.balance,
        a.created_at AS CreatedAt,
        a.account_status::text AS AccountStatus
    FROM account AS a
    """;


    public const string CheckingDetails =
   """
    WITH account AS (
        INSERT INTO 
            accounts.account_details(
                customer_id,
                account_number,
                account_type,
                currency,
                account_status    
            )
        SELECT
            @CustomerId,
            @AccountNumber,
            'Checking',
            @Currency,
            'Active'
        WHERE EXISTS (
            SELECT 1 FROM users.customer_details WHERE id = @CustomerId
        )
        RETURNING
            id,
            customer_id,
            account_number,
            account_type,
            currency,
            balance,
            created_at,
            account_status
    ),
    checking AS (
        INSERT INTO accounts.checking_account(
            account_id
        )
        SELECT
            a.id
        FROM account AS a
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
        WHERE a.id IS NOT NULL
    )
    SELECT 
        a.id,
        a.customer_id AS CustomerId,
        a.account_number AS AccountNumber,
        a.account_type::text AS AccountType,
        a.currency,
        a.balance,
        a.created_at AS CreatedAt,
        a.account_status::text AS AccountStatus
    FROM account AS a
    """;
}