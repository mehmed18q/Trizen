namespace Trizen.Infrastructure.Base.Response;

public abstract class BaseResponse
{
    public string? Message { get; init; }
    public bool IsSuccess { get; init; }
}