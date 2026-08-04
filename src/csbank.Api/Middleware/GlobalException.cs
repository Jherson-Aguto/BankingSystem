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
            ConflictException => (StatusCodes.Status409Conflict, exception.Message),

            _ => (StatusCodes.Status500InternalServerError, "An unexpected server error occured")
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
            logger.LogError($"{exception} Unhandled Exception: {exception.Message}");
        else
            logger.LogWarning($"Exception {statusCode}: {exception.Message}");

        httpContext.Response.StatusCode = statusCode;

        var errorResponse = ApiResponse<string>.Fail(success: false, data: null, errorMessage: clientMessage, errorCode: statusCode.ToString());

        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

        return true;
    }
}

public class NotFoundException(string message) : Exception(message);
public class ValidationException(string message) : Exception(message);
public class ConflictException(string message) : Exception(message);