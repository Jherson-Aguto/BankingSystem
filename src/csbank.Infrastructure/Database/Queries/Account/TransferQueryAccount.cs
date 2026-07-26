namespace CSbank.Infrastructure.Database.Queries;

public sealed class TransferQuery
{
    public const string Transfer =
    """
    WITH locked_account AS (
        SELECT
            ad.id,
            ad.customer_id,
            ad.balance
        FROM users.customer_details cd
        LEFT JOIN
            accounts.account_details ad
        ON cd.id = ad.customer_id
        WHERE
            ad.account_number IN (@AccountNumber, @RecipientAccountNumber)
        AND @TransferFundValue > 0
        ORDER BY id desc
        FOR UPDATE
    ),
    transfer_out AS (
        UPDATE accounts.account_details ad
        SET
            balance = ad.balance - @TransferFundValue
        FROM locked_account AS la
        WHERE
            ad.account_number = @AccountNumber
        AND la.id = ad.id
        AND ad.balance >= @TransferFundValue
        RETURNING
            ad.balance,
            ad.id,
            ad.customer_id
    ),
    transfer_in AS (
        UPDATE accounts.account_details ad
        SET
            balance = ad.balance + @TransferFundValue
        FROM transfer_out AS t_o
        WHERE
            ad.account_number = @RecipientAccountNumber
        AND t_o IS NOT NULL
        RETURNING
            ad.balance,
            ad.id
    ),
    transaction_transfer_out AS (
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
            t_o.id,
            'TransferOut',
            @TransferFundValue,
            t_o.balance + @TransferFundValue,
            t_o.balance,
            @ReferenceNumber,
            @Description
        FROM
            transfer_out AS t_o
        CROSS JOIN locked_account AS la
        WHERE la.id = t_o.id
        RETURNING *
    ),
    transaction_transfer_in AS (
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
            ti.id,
            'TransferIn',
            @TransferFundValue,
            ti.balance - @TransferFundValue,
            ti.balance,
            @ReferenceNumber,
            @Description
        FROM
            transfer_in AS ti
        CROSS JOIN locked_account AS la
        WHERE la.id = ti.id
        RETURNING *
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
            'Transaction',
            tto.id,
            'Updated',
            t_o.customer_id,
            jsonb_build_object(
                'balance', t_o.balance + @TransferFundValue,
                'Recipient balance', ti.balance - @TransferFundValue
            ),
            jsonb_build_object(
                'balance', t_o.balance,
                'Recipient balance', ti.balance            
            )
        FROM
            transaction_transfer_out AS tto
        CROSS JOIN transfer_out AS t_o
        CROSS JOIN transfer_in AS ti
        WHERE ti.id IS NOT NULL
        AND t_o.id IS NOT NULL
    )
    SELECT
        tto.id,
        tto.account_id AS AccountId,
        tto.transaction_type::text AS Transactiontype,
        tto.amount,
        tto.balance_before AS BalanceBefore,
        tto.balance_after AS BalanceAfter,
        tto.reference_number AS ReferenceNumber,
        tto.description,
        tto.created_at AS CreatedAt,
        tti.id,
        tti.account_id AS AccountId,
        tti.transaction_type::text AS Transactiontype,
        tti.amount,
        tti.balance_before AS BalanceBefore,
        tti.balance_after AS BalanceAfter,
        tti.reference_number AS ReferenceNumber,
        tti.description,
        tti.created_at AS CreatedAt
    FROM transaction_transfer_out AS tto
    CROSS JOIN transaction_transfer_in AS tti
    """;
}