namespace CSBank.Application.Interfaces.IRepositories;

public interface ISaveRefreshTokenRepository
{
    Task SaveRefreshTokenAsync(string refreshTokenHash, Guid userId);
}