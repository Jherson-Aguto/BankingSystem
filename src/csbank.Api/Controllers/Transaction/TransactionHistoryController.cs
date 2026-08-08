using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/histories")]
public class TransactionHistory(
    IReadTransactionHistory readTransaction
    ) : ControllerBase
{
    [Authorize]
    [HttpGet("{accountId:guid}")]
    public async Task<IActionResult> ReadTransactionHistoryAsync(
        [FromRoute] Guid accountId,
        [FromQuery] int pageNumber
    )
    {
        if (pageNumber < 1)
            throw new ValidationException("Page number must be greater than 1");

        var results = await readTransaction.ReadTransactionHistoryAsync(accountId, pageNumber);

        if (results is null)
            throw new NotFoundException("No transaction histories found");

        return Ok(
            ApiResponse<IEnumerable<TransactionDto?>?>.Ok(
                success: true,
                data: results
            ));
    }
}