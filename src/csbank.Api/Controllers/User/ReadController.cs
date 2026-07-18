using CSBank.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReadUserController(IReadUserService readUser) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> ByIdAsync(Guid id)
    {
        try
        {
            var user = await readUser.ByIdAsync(id);

            if (user is null)
            {
                return NotFound(new
                {
                    Message = "User not Found",
                    UserId = id
                });
            }

            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(statusCode: 500);
        }
    }
}