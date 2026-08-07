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

        bool result = await authService.LoginAsync(email, password);

        if (result == false)
            throw new ValidationException("Invalid email or password!");

        return Ok(
            ApiResponse<bool>.Ok(
                success: true,
                data: result
            ));
    }
}