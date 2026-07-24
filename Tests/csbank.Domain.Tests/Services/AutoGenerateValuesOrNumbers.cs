using CSbank.Domain.Services.Account;

namespace csbank.Domain.Tests;

public class AccountDomainServiceTest(AccountDomainService accountService) : IClassFixture<AccountDomainService>
{
    [Fact]
    public void ShouldGenerateReferenceNumber()
    {
        var referenceOutput = accountService.GenerateReferenceNumber();

        Console.WriteLine($"Reference Number: {referenceOutput}");

        Assert.NotNull(referenceOutput);
    }

    [Theory]
    [InlineData("PHP")]
    [InlineData("php")]
    [InlineData("USD")]
    [InlineData("usd")]
    public void ShouldGenerateAccountNumber(string value)
    {
        // Given
        var result = accountService.GenerateAccountNumber(value);
        // When
        Console.WriteLine($"Results: {result}");
        // Then
        Assert.NotNull(result);
    }
}