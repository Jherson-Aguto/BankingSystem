namespace CSbank.Infrastructure.Database.Queries;

public sealed class DepositQuery
{
    public const string DepositSavings =
    """
    WITH locked_account AS (
        SELECT
            sa.account_id,
            ad.customer_id,
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
            AND ad.account_status = 'Active'
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
            la.account_id,
            la.balance AS balance_before,
            sa.balance AS balance_after
    ),
    recorded_transaction AS (
        INSERT INTO
            transactions.transaction_history(
                account_id,
                transaction_type,
                amount,
                balance_before,
                balance_after,
                reference_number,
                description
        )
        SELECT
            ub.account_id,
            'Deposit',
            @DepositValue,
            ub.balance_before,
            ub.balance_after,
            @ReferenceNumber,
            CASE
                WHEN @Description IS NULL OR @Description = '' THEN 'No Description'
                ELSE @Description
            END
        FROM 
            updated_balance AS ub
        RETURNING
            id,
            created_at
    ),
    recorded_audit AS (
        INSERT INTO
            audit.audit_logs(
                entity_name,
                entity_id,
                action,
                performed_by,
                old_values,
                new_values
    )
        SELECT
            'SavingsAccount',
            ub.account_id,
            'Updated',
            la.customer_id,
            jsonb_build_object(
                'balance', ub.balance_before
            ),
            jsonb_build_object(
                'balance', ub.balance_after
            )
        FROM
            locked_account AS la
        CROSS JOIN
            updated_balance AS ub
    )
    SELECT
        ub.account_id AS AccountId,
        rt.id AS TransactionId,
        ub.balance_before AS BeforeBalance,
        ub.balance_after AS AfterBalance,
        rt.created_at AS TransactionDate
    FROM 
        updated_balance AS ub
    CROSS JOIN
        recorded_transaction AS rt;
    """;

    public const string DepositChecking =
    """
    WITH locked_account AS (
        SELECT
            ca.account_id,
            ca.balance,
            ad.customer_id
        FROM 
            accounts.account_details ad
        JOIN 
            accounts.checking_account ca
            ON ad.id = ca.account_id
        WHERE
            ad.id = @AccountId
            AND ad.account_number = @AccountNumber
            AND @DepositValue > 0
            AND ad.account_status = 'Active'
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
            la.account_id,
            la.balance AS balance_before,
            ca.balance AS balance_after
    ),
    recorded_transaction AS (
        INSERT INTO 
            transactions.transaction_history(
                account_id,
                transaction_type,
                amount,
                balance_before,
                balance_after,
                reference_number,
                description    
        )
        SELECT
            ub.account_id,
            'Deposit',
            @DepositValue,
            ub.balance_before,
            ub.balance_after,
            @ReferenceNumber,
            CASE
                WHEN @Description IS NULL OR @Description = '' THEN 'No description'
                ELSE @Description
            END
        FROM 
            updated_balance AS ub
        RETURNING
            id,
            created_at
    ),
    recorded_audit AS (
        INSERT INTO
            audit.audit_logs(
                entity_name,
                entity_id,
                action,
                performed_by,
                old_values,
                new_values
    )
        SELECT
            'CheckingAccount',
            ub.account_id,
            'Updated',
            la.customer_id,
            jsonb_build_object(
                'balance', ub.balance_before
            ),
            jsonb_build_object(
                'balance', ub.balance_after
            )
        FROM
            locked_account AS la
        CROSS JOIN
            updated_balance AS ub
    )
    SELECT
        ub.account_id AS AccountId,
        rt.id AS TransactionId,
        ub.balance_before AS BeforeBalance,
        ub.balance_after AS AfterBalance,
        rt.created_at AS TransactionDate
    FROM
        updated_balance AS ub
    CROSS JOIN
        recorded_transaction AS rt;
    """;
}