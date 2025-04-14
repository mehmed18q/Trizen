using System.ComponentModel.DataAnnotations;
using Trizen.Data.Destination.ViewModel;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base;

namespace Trizen.Data.Destination.Dto;

public record SearchDestinationDto
{
    [Display(Name = Resource.Title)]
    public string? Title { get; set; }

    [Display(Name = Resource.DestinationType)]
    public int? DestinationTypeId { get; set; }

    [Display(Name = Resource.Category)]
    public int? CategoryId { get; set; }

    public int UserId { get; set; }
    public Pagination Pagination { get; set; } = new();

    public List<DestinationViewModel> Destinations { get; set; } = [];

}
