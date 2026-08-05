using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class AuthService(
    IPasswordService passwordService,
    IReadUserRepository readUser)
    : IAuthService
{
    public async Task<bool> LoginAsync(string email, string password)
    {
        UserCredentials? result = await readUser.ByEmailAsync(email);

        if (result?.PasswordHash is null)
            return false;

        return passwordService.Verify(password, result.PasswordHash);
    }
}