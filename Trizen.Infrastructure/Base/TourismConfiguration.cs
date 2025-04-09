using Trizen.Infrastructure.Enumerations;

namespace Trizen.Infrastructure.Base;

public record TrizenConfiguration
{
    public double EntryGiftAmount { get; set; }
    public UserRoles DefaultUserRole { get; set; }
    public string InviteCode { get; set; } = null!;
}
