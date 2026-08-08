using System.Security.Claims;
using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/users")]

public class AccountsController(
    IRegisterAccountsService registerAccounts)
    : ControllerBase
{
    [Authorize]
    [HttpPost("accounts")]
    public async Task<IActionResult> DetailsAsync(
        [FromQuery] string currency,
        [FromQuery] AccountTypes accountType)
    {
        Guid id = Guid.Parse(
          User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        AccountDto? data = await registerAccounts.DetailsAsync(id, currency, accountType);

        if (data is null)
            throw new NotFoundException("Failed to register account.");

        return Ok(
            ApiResponse<AccountDto>
            .Ok(success: true,
                data));
    }
}