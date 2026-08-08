using System.Security.Claims;
using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UpdateUserController(
    IUpdateUserService updateUser) : ControllerBase
{
    [Authorize]
    [HttpPatch("")]
    public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserRequest? dto)
    {
        if (dto is null)
            throw new NotFoundException("No update needed");

        Guid id = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        dto = dto with
        {
            Id = id
        };

        UpdateUserRequest? data = await updateUser.UpdateUserDetails(dto);

        if (data is null)
            throw new NotFoundException($"No user id found: {dto.Id} ");

        return Ok(
            ApiResponse<UpdateUserRequest?>.Ok(
                success: true,
                data: data
            ));
    }
}