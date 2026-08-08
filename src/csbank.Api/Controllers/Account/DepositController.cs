using CSBank.Application.Interfaces.Services;
using CSBank.Api.Middleware;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/deposits")]
public class DepositController(IDepositService deposit) : ControllerBase
{
    [Authorize]
    [HttpPost("")]
    public async Task<IActionResult>
        DepositAmount([FromBody] RequestDepositUpperDto requestDepositDto)
    {
        if (requestDepositDto.DepositValue <= 0)
            throw new ValidationException("Deposit amount must be greater than 0");

        TransactionDto? result = await deposit.DepositAmountAsync(requestDepositDto);

        if (result is null)
            throw new NotFoundException("Deposit is not successful.");

        return Ok(
            ApiResponse<TransactionDto>.Ok(
                success: true,
                data: result
            )
        );
    }
}