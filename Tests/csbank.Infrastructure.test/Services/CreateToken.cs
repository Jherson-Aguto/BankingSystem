using CSBank.Application.Models;
using CSBank.Application.Models.Auth;
using CSBank.Infrastructure.Utils;
using Microsoft.Extensions.Options;

namespace CSBank.Infrastructure.Test.Services;

public class CreateTokenTest
{
    private readonly CreateToken _create;

    public CreateTokenTest()
    {
        var jwtOptions = Options.Create(
            new JwtOptions
            {
                Secret = "YourSuperSecretKeyThatIsAtLeast32CharactersLong",
                Issuer = "CSBank",
                Audience = "CSBank.Api",
                ExpiryInMinutes = 15
            });

        _create = new CreateToken(jwtOptions);
    }


    [Fact]
    public void ShouldGenerateAccessToken()
    {
        // Given
        var input = new UserClaimsDto(
            Email: "jherson.dev@gmail.com",
            UserId: new Guid("365320c0-9d1f-44e3-aea3-e066f2ccee0f"),
            Role: "Customer"
        );
        // When
        var result = _create.CreateAccessTokenAsync(input);
        // Then

        Console.WriteLine($"access Token: {result}");

        Assert.NotNull(result);
    }
}