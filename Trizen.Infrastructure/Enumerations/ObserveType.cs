using System.ComponentModel.DataAnnotations;

namespace Trizen.Infrastructure.Enumerations;

public enum ObserveType
{
    [Display(Name = Resource.Visit)]
    Visit,
    [Display(Name = Resource.Like)]
    Like,
}
