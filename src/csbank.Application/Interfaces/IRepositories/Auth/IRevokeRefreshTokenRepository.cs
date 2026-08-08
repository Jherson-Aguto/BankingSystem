namespace CSBank.Application.Interfaces.IRepositories;

public interface IRevokeRefreshTokenRepository
{
    Task RevokeRefreshTokenAsync(Guid userId);
}