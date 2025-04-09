using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Destination.Dto;

public record UpdateDestinationDto : BaseDestinationDto
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    public IFormFile? UploadImage { get; set; }
}
