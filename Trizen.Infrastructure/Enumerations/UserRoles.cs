using System.ComponentModel.DataAnnotations;

namespace Trizen.Infrastructure.Enumerations;

public enum UserRoles
{
    [Display(Name = Resource.User)]
    User,
    [Display(Name = Resource.Admin)]
    Admin
}
