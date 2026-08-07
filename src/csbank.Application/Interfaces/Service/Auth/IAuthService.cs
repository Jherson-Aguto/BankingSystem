namespace CSBank.Application.Interfaces.Services;

public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password);
}