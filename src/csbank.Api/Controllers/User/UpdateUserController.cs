using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UpdateUserController(
    IUpdateUserService updateUser) : ControllerBase
{
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] UpdateUserRequest? dto)
    {
        if (dto is null)
            throw new NotFoundException("No update needed");

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