using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterUserController(IRegisterCustomerService _register) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RequestUserDetailsDto requestUserDetailsDto)
    {
        var result = await _register.CustomerAsync(requestUserDetailsDto);

        if (result is null)
            throw new NotFoundException("Cannot register information.");

        return Ok(ApiResponse<UserDetailsDto?>
            .Ok(
                success: true,
                data: result));
    }
}