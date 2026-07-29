using CSbank.Domain.Entities;
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
    [HttpPost("account/{customerId::Guid}")]
    public async Task<IActionResult> DetailsAsync(
        [FromRoute] Guid customerId,
        [FromQuery] string currency,
        [FromQuery] AccountTypes accountType)
    {
        AccountDto? data = await registerAccounts.DetailsAsync(customerId, currency, accountType);

        if (data is null)
            throw new NotFoundException("Failed to register account.");

        return Ok(
            ApiResponse<AccountDto>
            .Ok(success: true,
                data));
    }
}