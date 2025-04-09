using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Trizen.Data.Tour;
using Trizen.Infrastructure;

namespace Trizen.Data.Tour.Dto;

public record UpdateTourDto : BaseTourDto
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    public IFormFile? UploadImage { get; set; }
}
