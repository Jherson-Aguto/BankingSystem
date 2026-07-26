using CSbank.Application.Interfaces.Services;
using CSbank.Application.Models;
using CSBank.Api.Middleware;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepositController(IDepositService deposit) : ControllerBase
{
    [HttpPost("amount")]
    public async Task<IActionResult> DepositAmount(RequestDepositDto requestDepositDto, AccountTypes accountType)
    {
        return Ok(deposit.DepositAmountAsync(requestDepositDto, accountType));
    }
}