using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.DataLayer.Entities;

public class Destination
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

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

    [ForeignKey(nameof(DestinationTypeId))]
    public virtual DestinationType DestinationType { get; set; }

    public virtual ICollection<DestinationCategory> DestinationCategories { get; set; } = [];

}