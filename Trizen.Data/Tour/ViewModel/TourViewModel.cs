using System.ComponentModel.DataAnnotations;
using Trizen.Data.Destination.ViewModel;
using Trizen.Infrastructure;

namespace Trizen.Data.Tour.ViewModel;

public record TourViewModel : BaseTourDto
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Destination)]
    public DestinationViewModel Destination { get; set; } = null!;

    [Display(Name = Resource.TourType)]
    public string TourTypeTitle { get; set; } = null!;

    public List<TourCategoryViewModel> Categories { get; set; } = [];

    public bool Liked { get; set; }
    public int Capacity { get; set; }
    public float? Score { get; set; }
}
