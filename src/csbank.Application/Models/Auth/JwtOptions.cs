namespace CSBank.Application.Models.Auth;

public class JwtOptions
{
    public string Secret { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public int ExpiryInMinutes { get; init; }
}