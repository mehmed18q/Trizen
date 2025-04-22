using Trizen.Data.Destination.ViewModel;

namespace Trizen.Data.Base.ViewModel;

public record HomeViewModel
{
    public List<DestinationViewModel> Destinations { get; set; }
    public int UsersCounts { get; set; }
    public int ToursCounts { get; set; }
    public int DestinationsCounts { get; set; }
}