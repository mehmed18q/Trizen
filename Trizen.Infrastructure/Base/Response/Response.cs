namespace Trizen.Infrastructure.Base.Response;

public class Response<T> : BaseResponse
{
    public T? Data { get; init; }

    public static Response<T> SuccessResult(T? data, string? message = null)
    {
        return new Response<T>()
        {
            Data = data,
            Message = message,
            IsSuccess = true,
        };
    }

    public static Response<T> FailResult(T? data, string? message = null)
    {
        return new Response<T>()
        {
            Data = data,
            Message = message,
            IsSuccess = false,
        };
    }
}
