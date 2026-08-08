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
    ICreateTokenService createToken,
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
        string refreshTokenHash = ConvertToHash(refreshToken);
        await saveRefreshToken.SaveRefreshTokenAsync(refreshTokenHash, result.UserId);

        return (accessToken: accessToken, refreshToken: refreshToken);
    }

    private string ConvertToHash(string refreshToken)
    {
        byte[] refreshTokenBytes = Encoding.UTF8.GetBytes(refreshToken);

        byte[] hashBytes = SHA256.HashData(refreshTokenBytes);

        return Convert.ToHexString(hashBytes);
    }
}