using Microsoft.AspNetCore.Diagnostics;
using Npgsql;
namespace CSBank.Api.Middleware;

public class ExceptionHandler(
    ILogger<ExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, clientMessage) = exception switch
        {
            NotFoundException => (StatusCodes.Status404NotFound, exception.Message),
            ValidationException => (StatusCodes.Status400BadRequest, exception.Message),
            ConflictException => (StatusCodes.Status409Conflict, exception.Message),
            PostgresException
            {
                SqlState: "23505",
                ConstraintName: "savings_account_pkey"
            }
                => (StatusCodes.Status409Conflict, "This account already has a savings account."),
            PostgresException
            {
                SqlState: "23505",
                ConstraintName: "checking_account_pkey"
            }
                => (StatusCodes.Status409Conflict, "This account already has a checking account."),

            _ => (StatusCodes.Status500InternalServerError, "An unexpected server error occured")
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
            logger.LogError($"{exception} Unhandled Exception: {exception.Message}");
        else
            logger.LogWarning($"Exception {statusCode}: {exception.Message}");

        httpContext.Response.StatusCode = statusCode;

        Error errorResponse = new Error(statusCode.ToString(), clientMessage);

        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

        return true;
    }
}

public record Error(string? StatusCode, string? Message);

public class NotFoundException(string message) : Exception(message);
public class ValidationException(string message) : Exception(message);
public class ConflictException(string message) : Exception(message);