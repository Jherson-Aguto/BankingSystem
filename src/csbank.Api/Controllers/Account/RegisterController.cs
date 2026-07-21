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
        Console.WriteLine($"Account Status controller: {accountDto.AccountStatus}");
        await registerAccounts.DetailsAsync(accountDto);
        return Ok(ApiResponse<string>.Ok(success: true, data: "Done!"));
    }
}