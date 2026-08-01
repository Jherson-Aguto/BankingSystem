using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/users")]

public class AccountsController(
    IRegisterAccountsService registerAccounts)
    : ControllerBase
{
    [HttpPost("{id:guid}/accounts")]
    public async Task<IActionResult> DetailsAsync(
        [FromRoute] Guid id,
        [FromQuery] string currency,
        [FromQuery] AccountTypes accountType)
    {
        AccountDto? data = await registerAccounts.DetailsAsync(id, currency, accountType);

        if (data is null)
            throw new NotFoundException("Failed to register account.");

        return Ok(
            ApiResponse<AccountDto>
            .Ok(success: true,
                data));
    }
}