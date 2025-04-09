using System.ComponentModel.DataAnnotations;
using Trizen.Data.Tour.ViewModel;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Data.Destination.ViewModel;


public record DestinationViewModel
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Title)]
    public string Title { get; set; } = null!;

    [Display(Name = Resource.Image)]
    public string? Image { get; set; }

    [Display(Name = Resource.GeographicalLocation)]
    public GeographicalLocation GeographicalLocation { get; set; }

    [Display(Name = Resource.GeographicalLocation)]
    public string GeographicalLocationTitle => GeographicalLocation.GetDisplayName();

    [Display(Name = Resource.DestinationType)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DestinationTypeId { get; set; }

    [Display(Name = Resource.DestinationType)]
    public string DestinationTypeTitle { get; set; } = null!;

    public List<DestinationCategoryViewModel> Categories { get; set; } = [];
}