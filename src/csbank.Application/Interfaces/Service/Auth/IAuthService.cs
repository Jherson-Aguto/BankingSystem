
namespace CSBank.Application.Interfaces.Services;

public interface IAuthService
{
    Task<(string? accessToken, string? refreshToken)> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken);
    Task<bool> LogoutAsync(string email, CancellationToken cancellationToken);
    Task<string?> RefreshTokenAsync(
        string email,
        string refreshToken,
        CancellationToken cancellationToken);
}