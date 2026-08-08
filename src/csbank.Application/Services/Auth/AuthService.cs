using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;

namespace CSBank.Application.Services;

public class AuthService(
    IPasswordService passwordService,
    IReadUserRepository readUser,
    IToken createToken,
    ISaveRefreshTokenRepository saveRefreshToken)
    : IAuthService
{
    public async Task<(string? accessToken, string? refreshToken)> LoginAsync(string email, string password)
    {
        UserCredentials? result = await readUser.ByEmailAsync(email);

        if (result?.PasswordHash is null)
            return (null, null);

        var userClaims = new UserClaimsDto(
            Email: email,
            UserId: result.UserId,
            Role: result.Role
        );

        bool verdict = passwordService.Verify(password, result.PasswordHash);

        if (!verdict)
            return (null, null);

        string accessToken = createToken.CreateAccessTokenAsync(userClaims);
        string refreshToken = createToken.CreateRefreshTokenAsync();

        //save refresh token hash
        string refreshTokenHash = createToken.ConvertToHash(refreshToken);
        await saveRefreshToken.SaveRefreshTokenAsync(refreshTokenHash, result.UserId);

        return (accessToken: accessToken, refreshToken: refreshToken);
    }

    public async Task<string?> RefreshTokenAsync(string email, string refreshToken)
    {
        UserCredentials? user = await readUser.ByEmailAsync(email);

        if (user is null || user.RefreshTokenHash is null)
            return null;

        string refreshTokenHash = createToken.ConvertToHash(refreshToken);

        if (user.RefreshTokenHash != refreshTokenHash)
            return null;

        var userClaims = new UserClaimsDto(
            Email: email,
            UserId: user.UserId,
            Role: user.Role
        );

        return createToken.CreateAccessTokenAsync(userClaims);
    }
}