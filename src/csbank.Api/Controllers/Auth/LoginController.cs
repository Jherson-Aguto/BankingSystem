using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class LoginController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromQuery] string email, [FromQuery] string password)
    {
        if (email is null || password is null)
            throw new NotFoundException("Email and Password is required");

        (string? a, string? b) = await authService.LoginAsync(email, password);

        if (a is null || b is null)
            throw new ValidationException("Invalid email or password!");

        string accessToken = a;
        string refreshToken = b;

        return Ok(
            ApiResponse<string[]>.Ok(
                success: true,
                data: [accessToken, refreshToken]
            ));
    }
}