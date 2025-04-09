using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.Data.Destination;

public record BaseDestinationDto
{
    [Display(Name = Resource.Title)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public required string Title { get; set; }

    [Display(Name = Resource.GeographicalLocation)]
    [Required(ErrorMessage = Message.RequiredError)]
    public GeographicalLocation GeographicalLocation { get; set; }

    [Display(Name = Resource.Image)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public string? Image { get; set; }

    [Display(Name = Resource.DestinationType)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DestinationTypeId { get; set; }
}