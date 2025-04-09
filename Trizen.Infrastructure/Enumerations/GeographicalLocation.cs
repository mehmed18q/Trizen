using System.ComponentModel.DataAnnotations;

namespace Trizen.Infrastructure.Enumerations;

public enum GeographicalLocation
{
    [Display(Name = Resource.North)]
    North,
    [Display(Name = Resource.Northeast)]
    Northeast,
    [Display(Name = Resource.East)]
    East,
    [Display(Name = Resource.Southeast)]
    Southeast,
    [Display(Name = Resource.South)]
    South,
    [Display(Name = Resource.Southwest)]
    Southwest,
    [Display(Name = Resource.West)]
    West,
    [Display(Name = Resource.Northwest)]
    Northwest,
    [Display(Name = Resource.Center)]
    Center
}
