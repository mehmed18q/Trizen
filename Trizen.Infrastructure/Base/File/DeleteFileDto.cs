namespace Trizen.Infrastructure.Base.File;

public record DeleteFileDto
{
    public required string Entity { get; set; }
    public required string FileName { get; set; }
}