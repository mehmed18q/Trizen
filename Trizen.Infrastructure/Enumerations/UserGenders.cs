using System.ComponentModel.DataAnnotations;

namespace Trizen.Infrastructure.Enumerations;

public enum UserGenders
{
    [Display(Name = Resource.Unset)]
    Unset,
    [Display(Name = Resource.Man)]
    Man,
    [Display(Name = Resource.Woman)]
    Woman
}
