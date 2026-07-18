namespace CSBank.Application;

public record Response<T>(bool Success, T Data, string? ErrorMessage, string? ErrorCode)
{
    public static Response<T> Ok(bool success, T data)
     => new Response<T>(Success: success, Data: data, null, null);

    public static Response<T> Fail(bool success, T data, string? errorMessage, string? errorCode)
     => new Response<T>(Success: success, Data: data, ErrorMessage: errorMessage, ErrorCode: errorCode);
};
