namespace Trizen.Data.Base.ViewModel;

public record AboutUsViewModel
{
    public List<TeamViewModel> Team { get; set; } = [];
    public int UsersCounts { get; set; }
    public int ToursCounts { get; set; }
    public int DestinationsCounts { get; set; }
    public int TravelsCounts { get; set; }
}
