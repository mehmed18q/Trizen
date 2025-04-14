using System.ComponentModel.DataAnnotations;
using Trizen.Data.Tour.ViewModel;
using Trizen.Infrastructure;

namespace Trizen.Data.Destination.ViewModel;


public record DestinationViewModel
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Title)]
    public string Title { get; set; } = null!;

    [Display(Name = Resource.Image)]
    public string? Image { get; set; }

    [Display(Name = Resource.Description)]
    public string? Description { get; set; }

    [Display(Name = Resource.DestinationType)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DestinationTypeId { get; set; }

    [Display(Name = Resource.DestinationType)]
    public string DestinationTypeTitle { get; set; } = null!;

    public List<DestinationCategoryViewModel> Categories { get; set; } = [];
    public bool Liked { get; set; }
    public int ToursCount { get; set; }
}