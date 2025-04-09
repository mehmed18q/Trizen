using Microsoft.AspNetCore.Http;
using Trizen.Data.Tour;

namespace Trizen.Data.Tour.Dto;

public record CreateTourDto : BaseTourDto
{
    public IFormFile? UploadImage { get; set; }
}
