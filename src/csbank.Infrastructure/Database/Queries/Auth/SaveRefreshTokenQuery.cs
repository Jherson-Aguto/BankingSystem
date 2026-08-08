namespace CSBank.Infrastructure.Database.Queries;

public sealed class SaveRefreshTokenQuery
{
    public const string save =
    """
    WITH locked_account AS (
        SELECT *
        FROM users.user_credentials
        WHERE user_id = @userId
        FOR UPDATE
    ),
    updated_refresh_token AS (
        UPDATE users.user_credentials AS uc
        SET refresh_token_hash = @refreshTokenHash,
            expires_at = CURRENT_TIMESTAMP + INTERVAL '7 days',
            revoked_at = NULL
        FROM locked_account AS la
        WHERE uc.user_id = la.user_id
        RETURNING
            la.id as id,
            la.user_id as user_id,
            la.refresh_token_hash AS old_refresh_token,
            uc.refresh_token_hash AS new_refresh_token
    ),
    created_audit AS (
        INSERT INTO audit.audit_logs(
            entity_name,
            entity_id,
            action,
            performed_by,
            old_values,
            new_values
        )
        SELECT
            'Customer'::audit.entity_names,
            uc.id,
            'Login'::audit.actions,
            uc.user_id,
            json_build_object(
                'refresh_token_hash', uc.old_refresh_token
            ),
            json_build_object(
                'refresh_token_hash', uc.new_refresh_token
            )
        FROM updated_refresh_token AS uc
        WHERE uc.old_refresh_token IS NOT NULL
    )
    SELECT 1
    FROM locked_account AS la
    WHERE la.user_id IS NOT NULL
    """;
}