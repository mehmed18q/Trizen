using System.ComponentModel.DataAnnotations;

namespace Trizen.Infrastructure.Enumerations;

public enum TravelStatus
{
    [Display(Name = Resource.Processing)]
    Processing,
    [Display(Name = Resource.Cancelled)]
    Cancelled,
    [Display(Name = Resource.Paid)]
    Paid,
}
