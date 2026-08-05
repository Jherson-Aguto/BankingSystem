using CSBank.Application.Interfaces.Services;

namespace CSBank.Infrastructure.Utils;

public class PasswordService : IPasswordService
{
    public string Hash(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }

    public bool Verify(string password, string passwordHash)
        => BCrypt.Net.BCrypt.Verify(password, passwordHash);
}