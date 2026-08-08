
namespace CSBank.Application.Interfaces.Services;

public interface IAuthService
{
    Task<(string? accessToken, string? refreshToken)> LoginAsync(string email, string password);
}