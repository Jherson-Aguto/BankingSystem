namespace CSBank.Infrastructure.Database.Queries;

public sealed class RevokeRefreshTokenQuery
{
    public const string Revoke =
    """
    WITH locked_account AS (
        SELECT *
        FROM users.user_credentials
        WHERE user_id = @userId
        FOR UPDATE
    ),
    revoked_refresh_token_hash AS (
        UPDATE users.user_credentials AS uc
        SET
            refresh_token_hash = NULL,
            expires_at = CURRENT_TIMESTAMP,
            revoked_at = CURRENT_TIMESTAMP
        FROM locked_account AS la
        WHERE uc.user_id = la.user_id
        RETURNING
            uc.user_id AS user_id,
            uc.id AS id,
            la.refresh_token_hash AS refresh_token_hash
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
            'Logout'::audit.actions,
            uc.user_id,
            json_build_object(
                'refresh_token_hash', NULL
            ),
            json_build_object(
                'refresh_token_hash', uc.refresh_token_hash
            )
        FROM revoked_refresh_token_hash AS uc
        WHERE uc.user_id IS NOT NULL
    )
    SELECT 1 FROM locked_account AS la
    WHERE la.user_id IS NOT NULL
    """;
}