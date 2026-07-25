using System.Collections.Concurrent;
using CSbank.Domain.Services.Account;

namespace CSbank.Domain.Test.Services;

public class AccountTest1(AccountDomainService accountService) : IClassFixture<AccountDomainService>
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("    ")]
    [InlineData(null)]
    public void ShouldThrowError(string? currency)
    {
        Assert.Throws<ArgumentException>(
            () => accountService.GenerateAccountNumber(currency!));
    }

    [Theory]
    [InlineData("PHP")]
    [InlineData("USD")]
    [InlineData("EUR")]
    [InlineData("GPB")]
    [InlineData("JPY")]
    public void ShouldGenerateUniqueAccountNumber(string? currency)
    {
        ConcurrentBag<string> results = new();

        Parallel.For(0, 100_000,
        i =>
            {
                results.Add(accountService.GenerateAccountNumber(currency!));
            });

        Assert.Distinct(results);
    }


    [Fact]
    public void ShouldGenerateUniqueReferenceNumber()
    {
        ConcurrentBag<string> results = new();

        Parallel.For(0, 100_000,
        i =>
        {
            results.Add(accountService.GenerateReferenceNumber());
        });

        Assert.Distinct(results);
    }
}