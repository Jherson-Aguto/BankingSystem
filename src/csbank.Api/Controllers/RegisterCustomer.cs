using CSBank.Application.Interfaces;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterCustomerController(IRegisterCustomer _register) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest r)
    {
        try
        {
            await _register.Register(r.CustomerDto, r.PrivateInfoDto);
            return Ok("Post Register ran successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Registration failed: {ex}");
        }
    }
    public record RegisterRequest(CustomerDto CustomerDto, PrivateInfoDto PrivateInfoDto);
}