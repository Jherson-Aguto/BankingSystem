using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface IToken
{
    string CreateAccessTokenAsync(UserClaimsDto userClaims);
    string CreateRefreshTokenAsync();
    string ConvertToHash(string refreshToken);
}