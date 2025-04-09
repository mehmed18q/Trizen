using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Tour.ViewModel;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.Presentation.ViewComponents;

[ViewComponent]
public class ToursListComponent(ITourService tourService) : ViewComponent
{
    private readonly ITourService _tourService = tourService;

    public async Task<IViewComponentResult> InvokeAsync(SearchTourViewModel model)
    {
        TourListViewModel viewModel = new()
        {
            SearchModel = model,
        };

        if (model.CallerPage is CallerPage.Details or CallerPage.User)
        {
            ListResponse<TourViewModel> tours = await _tourService.GetSuggestedTours(model.UserId);
            viewModel.Tours = tours;
        }
        else
        {
            ListResponse<TourViewModel> tours = await _tourService.Search(model);
            viewModel.Tours = tours;
        }

        return await Task.FromResult((IViewComponentResult)View("ToursList", viewModel));
    }
}
