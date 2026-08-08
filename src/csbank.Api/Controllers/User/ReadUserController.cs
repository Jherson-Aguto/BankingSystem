using System.Security.Claims;
using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/users")]
public class ReadUserController(IReadUserService readUser) : ControllerBase
{
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> MeAsync()
    {
        Guid userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        string role = User.FindFirstValue(ClaimTypes.Role)!;

        UserDetailsDto? user = await readUser.ByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(
                $"User with ID: {userId} was not found");

        return Ok(new
        {
            response = ApiResponse<UserDetailsDto>.Ok(
            success: true,
            data: user),
            userRole = role
        });
    }
}