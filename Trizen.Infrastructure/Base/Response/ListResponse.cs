namespace Trizen.Infrastructure.Base.Response;

public class ListResponse<T> : BaseResponse
{
    public List<T> Data { get; init; } = [];
    public Pagination Pagination { get; init; } = new();

    public static ListResponse<T> SuccessResult(List<T>? data, string? message = null, Pagination? pagination = null)
    {
        return new ListResponse<T>()
        {
            Data = data ?? [],
            Message = message,
            Pagination = pagination ?? new(),
            IsSuccess = true
        };
    }

    public static ListResponse<T> FailResult(List<T>? data, string? message = null, Pagination? pagination = null)
    {
        return new ListResponse<T>()
        {
            Data = data ?? [],
            Message = message,
            Pagination = pagination ?? new(),
            IsSuccess = true
        };
    }
}
