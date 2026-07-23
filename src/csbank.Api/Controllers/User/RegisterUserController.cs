using CSBank.Api.Middleware;
using CSBank.Application.Interfaces;
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

        return Ok(ApiResponse<(
            CustomerDto,
            PrivateInfoDto)>
            .Ok(
                success: true,
                data: result));
    }
    public record RegisterRequest(CustomerDto CustomerDto, PrivateInfoDto PrivateInfoDto);
}