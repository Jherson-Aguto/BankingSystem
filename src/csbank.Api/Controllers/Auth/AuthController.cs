using System.Security.Claims;
using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromForm] string email, [FromForm] string password)
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

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody] string refreshToken, [FromQuery] string email)
    {
        string? result = await authService.RefreshTokenAsync(email, refreshToken);

        if (result is null)
            throw new UnauthorizedException("Session expired.");

        return Ok(
            ApiResponse<string>.Ok(
                success: true,
                data: result
            )
        );
    }
}