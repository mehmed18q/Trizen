using Microsoft.AspNetCore.Http;

namespace Trizen.Infrastructure.Base.File;

public record UploadFileDto
{
    public required string Entity { get; set; }
    public required IFormFile File { get; set; }
}