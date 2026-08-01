using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/users")]
public class ReadUserController(IReadUserService readUser) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ByIdAsync([FromRoute] Guid id)
    {
        UserDetailsDto? user = await readUser.ByIdAsync(id);

        if (user is null)
            throw new NotFoundException($"User with ID: {id} was not found");

        return Ok(ApiResponse<UserDetailsDto>.Ok(
            success: true,
            data: user));
    }
}