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
    public async Task<IActionResult> DetailsAsync([FromBody] AccountDto accountDto)
    {
        Guid data = await registerAccounts.DetailsAsync(accountDto);

        return Ok(
            ApiResponse<Guid>
            .Ok(success: true,
                data));
    }

    [HttpPost("accountType/{id:Guid}")]
    public async Task<IActionResult> AccountTypeCreationAsync(
        [FromRoute] Guid id,
        [FromQuery] string accountNumber,
        [FromQuery] bool? isChecking = false)
    {
        Guid? queriedAccountId = await registerAccounts.AccountTypeCreationAsync(id, accountNumber, isChecking);

        if (queriedAccountId is null)
            throw new NotFoundException($"No account matches Account id and number");

        return Ok(
            ApiResponse<string>
            .Ok(success: true,
            data: "Successfully Created!"));
    }
}