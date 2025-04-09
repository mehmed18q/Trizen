using Trizen.Data.User.ViewModel;

namespace Trizen.Data.Travel.ViewModel;

public record PassengerViewModel
{
    public int Id { get; set; }
    public ProfileViewModel User { get; set; }
}
