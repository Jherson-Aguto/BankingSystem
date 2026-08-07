namespace CSBank.Application.Models;

public record UserCredentials(
    Guid Id,
    Guid UserId,
    string PasswordHash,
    string? RefreshTokenHash,
    DateTime CreatedAt
);