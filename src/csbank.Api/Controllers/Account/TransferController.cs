using CSBank.Application.Models;
using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/transfers")]
public class TransferController(ITransferFundService fundService) : ControllerBase
{
    [Authorize]
    [HttpPost("")]
    public async Task<IActionResult> TransferFundAsync([FromBody] RequestTransferDto requestTransferDto, CancellationToken cancellationToken)
    {
        if (requestTransferDto.AccountNumber == requestTransferDto.RecipientAccountNumber)
            throw new ValidationException("You cannot transfer to your own account number.");

        if (requestTransferDto.TransferFundValue <= 0)
            throw new ValidationException("Transfer amount must be greater than 0");

        TransactionsDto? result = await fundService.TransferFund(requestTransferDto, cancellationToken);

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