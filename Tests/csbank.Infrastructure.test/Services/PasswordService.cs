using CSBank.Infrastructure.Utils;

namespace CSBank.Infrastructure.Test;

public class PasswordServiceTests
{
    private readonly PasswordService passwordService = new();

    [Fact]
    public void ShouldHashPasswordAndVerify()
    {
        string? passwordHash = passwordService.Hash("@Miki1cns21");

        Console.WriteLine($"Password Hash: {passwordHash}");

        Assert.True(passwordService.Verify("@Miki1cns21", passwordHash));
    }
}