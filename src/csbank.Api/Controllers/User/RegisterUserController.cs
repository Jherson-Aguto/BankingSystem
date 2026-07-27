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
    public async Task<IActionResult> Register([FromBody] RegisterRequest r)
    {
        var result = await _register.CustomerAsync(r.CustomerDto, r.PrivateInfoDto);

        if (result is null)
            throw new NotFoundException("Cannot register information.");

        return Ok(ApiResponse<UserDetailsDto?>
            .Ok(
                success: true,
                data: result));
    }
    public record RegisterRequest(CustomerDto CustomerDto, PrivateInfoDto PrivateInfoDto);
}