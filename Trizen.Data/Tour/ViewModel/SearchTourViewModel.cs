using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.Data.Tour.ViewModel;

public record SearchTourViewModel
{
    public CallerPage CallerPage { get; set; }

    [Display(Name = Resource.Title)]
    public string? Title { get; set; }

    [Display(Name = Resource.Destination)]
    public int? DestinationId { get; set; }

    [Display(Name = Resource.Category)]
    public int? CategoryId { get; set; }

    [Display(Name = Resource.TourType)]
    public int? TourTypeId { get; set; }

    [Display(Name = Resource.DestinationType)]
    public int? DestinationTypeId { get; set; }

    [Display(Name = Resource.GoDate)]
    public DateTime? GoDate { get; set; }

    [Display(Name = Resource.BackDate)]
    public DateTime? BackDate { get; set; }

    public int UserId { get; set; }

    public Pagination Pagination { get; set; } = new();

}
