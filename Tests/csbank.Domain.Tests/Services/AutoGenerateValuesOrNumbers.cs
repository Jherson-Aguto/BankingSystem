using System.Collections.Concurrent;
using CSbank.Domain.Services.Account;

namespace csbank.Domain.Tests.Services;

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
    public void Account_ShouldGenerateAccountNumber(string value)
    {
        // Given
        var result = accountService.GenerateAccountNumber(value);
        // When
        Console.WriteLine($"Results: {result}");
        // Then
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("PHP")]
    [InlineData("php")]
    [InlineData("USD")]
    [InlineData("usd")]
    public async Task Account_ShouldGenerateConcurrentAccountNumber(string value)
    {
        ConcurrentBag<string> numbers = [];

        Parallel.For(0, 1_000, _ =>
        {
            numbers.Add(accountService.GenerateAccountNumber(value));
        });

        Assert.All(numbers, number =>
            {
                Assert.StartsWith(value[..2].ToUpperInvariant(), number);
                Assert.Equal(16, number.Length);
            });
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("     ")]
    public void Account_InvalidCurrency_ShouldThrow(string? value)
    {
        Assert.Throws<ArgumentException>(() =>
            accountService.GenerateAccountNumber(value!));
    }

    [Theory]
    [InlineData("P")]
    public void Account_WhenCurrencyTooShort_ShouldThrow(string value)
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            accountService.GenerateAccountNumber(value));

        Assert.Equal(
            "Currency code must contain at least two characters. (Parameter 'currency')",
            ex.Message);
    }

}