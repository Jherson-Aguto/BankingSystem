using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AccountsController(
    IRegisterAccountsService registerAccounts)
    : ControllerBase
{
    [HttpPost("account")]
    public async Task<IActionResult> DetailsAsync(
        [FromBody] RequestAccountDto requestAccountDto,
        [FromQuery] AccountTypes accountType)
    {
        AccountDto? data = await registerAccounts.DetailsAsync(requestAccountDto, accountType);

        if (data is null)
            throw new NotFoundException("Failed to register account.");

        return Ok(
            ApiResponse<AccountDto>
            .Ok(success: true,
                data));
    }
}