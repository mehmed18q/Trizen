using Microsoft.AspNetCore.Http;

namespace Trizen.Data.Destination.Dto;

public record CreateDestinationDto : BaseDestinationDto
{
    public IFormFile? UploadImage { get; set; }
}
