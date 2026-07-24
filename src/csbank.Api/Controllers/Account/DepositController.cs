using CSbank.Application.Interfaces.Services;
using CSbank.Application.Models;
using CSBank.Api.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepositController(IDepositService deposit) : ControllerBase
{
    [HttpPost("deposit")]
    public async Task<IActionResult> DepositAsync(DepositDto depositDto)
    {
        if (depositDto.DepositValue <= 0)
            throw new ValidationException("Deposit amount must be greater than zero");

        DepositOutputDto? result = await deposit.DepositBalanceAsync(depositDto);

        return Ok(
            ApiResponse<DepositOutputDto>.Ok(
                success: true,
                data: result));
    }
}