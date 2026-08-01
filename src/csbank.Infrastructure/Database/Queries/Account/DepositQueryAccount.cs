namespace CSBank.Infrastructure.Database.Queries;

public sealed class DepositQuery
{
    public const string Deposit =
    """
    WITH locked_account AS (
        SELECT
            ad.customer_id,
            ad.balance,
            ad.id
        FROM
            accounts.account_details AS ad
        WHERE
            ad.account_number = @AccountNumber
        AND @DepositValue > 0
        AND ad.account_status = 'Active'
        FOR UPDATE
    ),
    updated_balance AS (
        UPDATE
            accounts.account_details AS ad
        SET balance = ad.balance + @DepositValue
        FROM locked_account AS la
        WHERE
            la.id = ad.id
        RETURNING
            la.balance AS balance_before,
            ad.balance AS balance_after,
            ad.id AS id,
            ad.customer_id
    ),
    created_transaction AS (
        INSERT INTO
            transactions.transaction_history AS th(
                account_id,
                transaction_type,
                amount,
                balance_before,
                balance_after,
                reference_number,
                description
            )
        SELECT
            ub.id,
            'Deposit',
            @DepositValue,
            ub.balance_before,
            ub.balance_after,
            @referenceNumber,
            @Description
        FROM
            updated_balance AS ub
        CROSS JOIN
            locked_account AS la
        WHERE
            ub.id = la.id
        RETURNING
            th.id,
            th.account_id,
            th.transaction_type,
            th.amount,
            th.balance_before,
            th.balance_after,
            th.reference_number,
            th.description,
            th.created_at
    ),
    recorded_audit AS (
        INSERT INTO
            audit.audit_logs (
                entity_name,
                entity_id,
                action,
                performed_by,
                old_values,
                new_values
            )
        SELECT
            'Transaction',
            ct.id,
            'Updated',
            ub.customer_id,
            jsonb_build_object(
                'balance', ub.balance_before
            ),
            jsonb_build_object(
                'balance', ub.balance_after
            )
        FROM
            updated_balance AS ub
        CROSS JOIN
            locked_account AS la
        CROSS JOIN
            created_transaction AS ct
        WHERE
            la.id = ub.id
    )
    SELECT
        ct.id,
        ct.account_id AS AccountId,
        ct.transaction_type::text AS TransactionType,
        ct.amount,
        ct.balance_before AS BalanceBefore,
        ct.balance_after AS BalanceAfter,
        ct.reference_number AS ReferenceNumber,
        ct.description,
        ct.created_at AS CreatedAt
    FROM created_transaction as ct
    """;
}