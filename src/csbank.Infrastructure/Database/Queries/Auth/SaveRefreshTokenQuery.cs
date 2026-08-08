namespace CSBank.Infrastructure.Database.Queries;

public sealed class SaveRefreshTokenQuery
{
    public const string save = 
    """
    UPDATE users.user_credentials
    SET
        refresh_token_hash = @refreshTokenHash
    WHERE user_id = @userId
    """;
}