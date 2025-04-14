using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Destination;

public record BaseDestinationDto
{
    [Display(Name = Resource.Title)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public required string Title { get; set; }

    [Display(Name = Resource.Description)]
    [Required(ErrorMessage = Message.RequiredError)]
    public string? Description { get; set; }

    [Display(Name = Resource.Image)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public string? Image { get; set; }

    [Display(Name = Resource.DestinationType)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DestinationTypeId { get; set; }
}