using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Tour.ViewModel;

namespace Trizen.Presentation.ViewComponents;

[ViewComponent]
public class SearchToursComponent(IListService listService) : ViewComponent
{
    private readonly IListService _listService = listService;

    public async Task<IViewComponentResult> InvokeAsync(SearchTourViewModel model)
    {
        ViewBag.TourTypes = await _listService.TourTypes(model.TourTypeId);
        ViewBag.Destinations = await _listService.Destinations(model.DestinationId);
        ViewBag.DestinationTypes = await _listService.DestinationTypes(model.DestinationTypeId);

        return await Task.FromResult((IViewComponentResult)View("SearchTours", model));
    }
}
