using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Tour.ViewModel;

public record TourCategoryViewModel
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Title)]
    public string Title { get; set; } = null!;
}

public record DestinationCategoryViewModel
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Title)]
    public string Title { get; set; } = null!;
}