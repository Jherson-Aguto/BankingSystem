using CSBank.Application.Models;
using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSbank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransferController(ITransferFundService fundService) : ControllerBase
{
    [HttpPost("fund")]
    public async Task<IActionResult> TransferFundAsync([FromBody] RequestTransferDto requestTransferDto)
    {
        if (requestTransferDto.TransferFundValue <= 0)
            throw new ValidationException("Transfer amount must be greater than 0");

        TransactionsDto? result = await fundService.TransferFund(requestTransferDto);

        if (result is null)
            throw new NotFoundException("Failed to transfer funds.");

        return Ok(
            ApiResponse<TransactionsDto>.Ok(
                success: true,
                data: result
            )
        );
    }
}