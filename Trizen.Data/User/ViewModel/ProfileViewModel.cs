using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Data.User.ViewModel;

public class ProfileViewModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? FullName => FirstName.IsNotEmpty() || LastName.IsNotEmpty() ? $"{FirstName} {LastName}" : UserName;
    public DateTime? BirthDay { get; set; }
    public string? NationalCode { get; set; }
    public int? PersonalityId { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? ImageProfile { get; set; }
    public double WalletAmount { get; set; }
    public UserRoles Role { get; set; }
    public bool IsProfileCompleted => FirstName.IsNotEmpty() && LastName.IsNotEmpty() && BirthDay.HasValue && NationalCode.IsNotEmpty() && PersonalityId.IsNotZeroOrNull() && PhoneNumber.IsNotEmpty();
    public bool IsSetPersonality => PersonalityId.IsNotZeroOrNull();
}
