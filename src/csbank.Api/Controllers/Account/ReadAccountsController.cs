using System.Security.Claims;
using CSBank.Api.Middleware;
using CSBank.Application.Interfaces.Services;
using CSBank.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBank.Api.Controllers;

[ApiController]
[Route("api/users")]
public class ReadAccountsController(
    IReadAccountsServices readAccounts
) : ControllerBase
{
    [Authorize]
    [HttpGet("accounts")]
    public async Task<IActionResult> ReadAccountsAsync([FromQuery] int pageNumber, CancellationToken cancellationToken)
    {
        if (pageNumber < 0)
            throw new ValidationException("Page number must be greater than 0");

        Guid id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var results = await readAccounts.AccountDetails(id, pageNumber, cancellationToken);

        if (results is null || !results.Any())
            throw new NotFoundException("No accounts found");

        return Ok(
            ApiResponse<List<AccountDto>>.Ok(
                success: true,
                data: results!
            )
        );
    }
}