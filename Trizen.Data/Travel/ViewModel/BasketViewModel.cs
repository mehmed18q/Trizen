using Trizen.Data.Tour.ViewModel;
using Trizen.Data.User.ViewModel;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Data.Travel.ViewModel;

public record BasketViewModel
{
    public int Id { get; set; }
    public TourViewModel Tour { get; set; }
    public ProfileViewModel User { get; set; }
    public DateTime RegisterTime { get; set; }
    public TravelStatus Status { get; set; }
    public string StatusTitle => Status.GetDisplayName();
    public List<PassengerViewModel> PassengersList { get; set; }
    public string Passengers => string.Join(",", PassengersList?.Select(passenger => passenger.User.Id)?.ToList() ?? []);

}