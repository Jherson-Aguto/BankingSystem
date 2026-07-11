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
            var result = await _register.Register(r.CustomerDto, r.PrivateInfoDto);

            return Ok(new RegisterRequest(
                result.customerData,
                result.privateInfoData
            ));
        }
        catch (Exception ex)
        {
            return BadRequest($"Registration failed: {ex}");
        }
    }
    public record RegisterRequest(CustomerDto CustomerDto, PrivateInfoDto PrivateInfoDto);
}