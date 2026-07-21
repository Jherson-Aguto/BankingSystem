namespace CSBank.Api.Middleware;

public record ApiResponse<T>(
    bool Success,
    T? Data,
    string? ErrorMessage = null,
    string? ErrorCode = null)
{
    public static ApiResponse<T> Ok(bool success, T? data)
     => new ApiResponse<T>(Success: success, Data: data);

    public static ApiResponse<T> Fail(bool success, T? data, string? errorMessage, string? errorCode)
     => new ApiResponse<T>(Success: success, Data: data, ErrorMessage: errorMessage, ErrorCode: errorCode);
};
