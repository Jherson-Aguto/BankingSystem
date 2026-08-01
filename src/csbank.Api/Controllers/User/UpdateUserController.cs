using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UpdateUserController(
    IUpdateUserService updateUser) : ControllerBase
{
    [HttpPost("data")]
    public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserRequest? dto)
    {
        if (dto is null)
            throw new NotFoundException("No update needed");

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