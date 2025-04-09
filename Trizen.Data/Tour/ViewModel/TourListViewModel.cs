using Trizen.Infrastructure.Base.Response;

namespace Trizen.Data.Tour.ViewModel;

public record TourListViewModel
{
    public SearchTourViewModel SearchModel { get; set; } = new();
    public ListResponse<TourViewModel> Tours { get; set; } = new();
}