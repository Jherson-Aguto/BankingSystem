namespace CSbank.Infrastructure.Database.Queries;

public sealed class DepositQuery
{
    public const string DepositSavings =
    """
    WITH locked_account AS (
        SELECT
            sa.account_id,
            sa.balance
        FROM 
            accounts.account_details ad
        JOIN 
            accounts.savings_account sa
            ON ad.id = sa.account_id
        WHERE 
            ad.id = @AccountId
            AND ad.account_number = @AccountNumber
            AND @DepositValue > 0
        FOR UPDATE
    ),
    updated_balance AS (
        UPDATE
            accounts.savings_account AS sa
        SET
            balance = sa.balance + @DepositValue
        FROM 
            locked_account AS la
        WHERE 
            la.account_id = sa.account_id
        RETURNING
            la.account_id AS account_id,
            la.balance AS before_balance,
            sa.balance AS after_balance
    )
    SELECT
        account_id AS AccountId,
        before_balance AS BeforeBalance,
        after_balance AS AfterBalance
    FROM
        updated_balance;
    """;

    public const string DepositChecking =
    """
    WITH locked_account AS (
        SELECT
            ca.account_id,
            ca.balance
        FROM 
            accounts.account_details ad
        JOIN 
            accounts.checking_account ca
            ON ad.id = ca.account_id
        WHERE
            ad.id = @AccountId
            AND ad.account_number = @AccountNumber
            AND @DepositValue > 0
        FOR UPDATE
    ),
    updated_balance AS (
        UPDATE
            accounts.checking_account AS ca
        SET
            balance = ca.balance + @DepositValue
        FROM 
            locked_account AS la
        WHERE
            la.account_id = ca.account_id
        RETURNING
            la.account_id AS account_id,
            la.balance AS before_balance,
            ca.balance AS after_balance
    )
    SELECT
        account_id AS AccountId,
        before_balance AS BeforeBalance,
        after_balance AS AfterBalance
    FROM
        updated_balance
    """;
}