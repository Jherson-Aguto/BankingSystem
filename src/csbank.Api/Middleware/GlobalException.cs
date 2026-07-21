using Microsoft.AspNetCore.Diagnostics;
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