using CSBank.Application.Models;

namespace CSBank.Application.Interfaces.IRepositories;

public interface ICreateTokenService
{
    string CreateAccessTokenAsync(UserClaimsDto userClaims);
    string CreateRefreshTokenAsync();
}