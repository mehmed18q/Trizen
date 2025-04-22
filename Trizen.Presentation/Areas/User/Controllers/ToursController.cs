using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Destination.ViewModel;
using Trizen.Data.Tour.Dto;
using Trizen.Data.Tour.ViewModel;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Extensions;
using Trizen.Presentation.ActionFilter;

namespace Trizen.Presentation.Areas.User.Controllers;

public class ToursController : BaseController<ToursController>
{
    private readonly ITourService _service;
    private readonly IListService _listService;
    private readonly IMapper _mapper;

    public ToursController(ILogger<ToursController> logger, ITourService service, IListService listService, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _listService = listService;
        _mapper = mapper;
    }

    [AdminActionFilter]
    public async Task<IActionResult> Index(SearchTourDto dto)
    {
        ListResponse<TourViewModel> tours = await _service.GetAll(dto);
        return View(tours.Data);
    }

    [AdminActionFilter]
    public async Task<IActionResult> Create()
    {
        ViewBag.Destinations = await _listService.Destinations();
        ViewBag.TourTypes = await _listService.TourTypes();

        return View(new CreateTourDto() { Title = string.Empty });
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [AdminActionFilter]
    public async Task<IActionResult> Create(CreateTourDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = await _service.Create(dto);
            if (result.IsSuccess)
            {
                return AreaRedirectToAction("Tours", nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        ViewBag.Destinations = await _listService.Destinations(dto.DestinationId);
        ViewBag.TourTypes = await _listService.TourTypes(dto.TourTypeId);

        return View(dto);
    }

    [AdminActionFilter]
    public async Task<IActionResult> Edit(int id)
    {
        Response<TourViewModel> tour = await _service.Get(id);
        if (!tour.IsSuccess || tour.Data is null)
        {
            return InternalServerErrorError(tour.Message);
        }

        ViewBag.Destinations = await _listService.Destinations(tour.Data.DestinationId);
        ViewBag.TourTypes = await _listService.TourTypes(tour.Data.TourTypeId);

        return View(_mapper.Map<UpdateTourDto>(tour.Data));
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [AdminActionFilter]
    public async Task<IActionResult> Edit(UpdateTourDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = await _service.Update(dto);
            if (result.IsSuccess)
            {
                return AreaRedirectToAction("Tours", nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        ViewBag.Destinations = await _listService.Destinations(dto.DestinationId);
        ViewBag.TourTypes = await _listService.TourTypes(dto.TourTypeId);

        return View(dto);
    }

    [AdminActionFilter]
    public async Task<IActionResult> Delete(int id)
    {
        Response<TourViewModel> tour = await _service.Get(id);
        if (!tour.IsSuccess || tour.Data is null)
        {
            return InternalServerErrorError(tour.Message);
        }

        _ = await _service.Delete(id);
        return AreaRedirectToAction("Tours", nameof(Index));
    }

    [AdminActionFilter]
    public async Task<IActionResult> Categories(int id)
    {
        ViewBag.Categories = await _listService.Categories();
        Response<TourViewModel> tour = await _service.Get(id);
        ViewBag.Tour = tour.Data;
        List<int> TourCategories = tour.Data?.Categories.Select(category => category.Id)?.ToList() ?? [];
        return View(new CategoryTourDto()
        {
            TourId = id,
            TourCategoriesList = TourCategories,
            TourCategories = TourCategories.Count != 0 ? string.Join(",", TourCategories) : string.Empty,
        });
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [AdminActionFilter]
    public async Task<IActionResult> Categories(CategoryTourDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = await _service.TourCategoryInsertUpdate(dto);
            if (result.IsSuccess && result.Data)
            {
                return AreaRedirectToAction("Tours", nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        ViewBag.Categories = await _listService.Categories();
        ViewBag.Tour = await _service.Get(dto.TourId);
        return View(dto);
    }

    public async Task<IActionResult> FavoriteTours()
    {
        int userId = User.GetUserId();
        ListResponse<TourViewModel> tour = await _service.GetFavoriteTours(userId);
        ListResponse<DestinationViewModel> destinations = await _service.GetFavoriteDestinations(userId);
        ViewBag.Destinations = destinations.Data;
        return View(tour.Data);
    }

    public async Task<IActionResult> My()
    {
        int userId = User.GetUserId();
        ListResponse<TourViewModel> tour = await _service.GetMyTours(userId);
        return View(tour.Data);
    }

    public async Task<IActionResult> Suggested()
    {
        int userId = User.GetUserId();
        ListResponse<TourViewModel> tour = await _service.GetSuggestedTours(userId);
        return View(tour.Data);
    }
}
