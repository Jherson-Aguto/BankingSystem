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
        if (requestDepositDto.DepositValue <= 0)
            throw new ValidationException("Deposit amount must be greater than 0");

        TransactionDto result = await deposit.DepositAmountAsync(requestDepositDto, accountType);

        return Ok(
            ApiResponse<TransactionDto>.Ok(
                success:true,
                data:result
            )
        );
    }
}