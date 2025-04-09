namespace Trizen.Data.User.ViewModel;

public record UserPanelViewModel
{
    public int UserId { get; set; }
    public bool IsProfileCompleted { get; set; }
    public bool IsImportantProfileCompleted { get; set; }
    public bool HaveTravel { get; set; }
    public string FullName { get; set; } = null!;
    public int UsersCounts { get; set; }
    public int ToursCounts { get; set; }
    public int DestinationsCounts { get; set; }
    public int TravelsCounts { get; set; }
}