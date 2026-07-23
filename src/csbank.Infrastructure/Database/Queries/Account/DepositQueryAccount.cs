namespace CSbank.Infrastructure.Database.Queries;

public sealed class DepositQuery
{
    public const string DepositSavings =
    """
    WITH locked_account AS (
        SELECT
            sa.account_id,
            sa.balance,
            ad.customer_id
        FROM accounts.account_details ad
        JOIN accounts.savings_account sa
            ON ad.id = sa.account_id
        WHERE
            ad.id = @accountId
            AND ad.account_number = @accountNumber
        FOR UPDATE
    ),
    updated_balance AS (
        UPDATE accounts.savings_account AS sa
        SET balance = sa.balance + @depositValue
        FROM locked_account AS la
        WHERE sa.account_id = la.account_id
        RETURNING
            sa.account_id AS saccount_id,
            sa.balance AS sbalance_after,
            la.balance AS sbalance_before,
            la.customer_id AS scustomer_id
    ),
    recorded_transaction AS (
        INSERT INTO transactions.transaction_history(
            account_id,
            transaction_type,
            amount,
            balance_before,
            balance_after,
            reference_number,
            description
    )
        SELECT
            saccount_id,
            @transactionType::transactions.transaction_types,
            @depositValue,
            sbalance_before,
            sbalance_after,
            @referenceNumber,
            @description
        FROM updated_balance
    ),
    created_audit AS (
        INSERT INTO audit.audit_logs(
            entity_name,
            entity_id,
            action,
            performed_by,
            old_values,
            new_values,
            ip_address,
            user_agent
    )
        SELECT
            @entityName::audit.entity_names,
            saccount_id,
            @action::audit.actions,
            scustomer_id,
            @oldValues,
            @newValues,
            @ipAddress,
            @userAgent
        FROM updated_balance
    )
    SELECT sbalance_after AS balance FROM updated_balance;
    """;
}