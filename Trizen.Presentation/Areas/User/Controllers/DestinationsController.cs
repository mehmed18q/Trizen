using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Destination.Dto;
using Trizen.Data.Tour.Dto;
using Trizen.Infrastructure.Base.Response;
using Trizen.Presentation.ActionFilter;

namespace Trizen.Presentation.Areas.User.Controllers;

[AdminActionFilter]
public class DestinationsController : BaseController<DestinationsController>
{
    private readonly IDestinationService _service;
    private readonly IListService _listService;
    private readonly IMapper _mapper;

    public DestinationsController(ILogger<DestinationsController> logger, IDestinationService service, IListService listService, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _listService = listService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(SearchDestinationDto dto)
    {
        ListResponse<Data.Destination.ViewModel.DestinationViewModel> destinations = await _service.GetAll(dto);
        return View(destinations.Data);
    }

    [AdminActionFilter]
    public async Task<IActionResult> Categories(int id)
    {
        ViewBag.Categories = await _listService.Categories();
        Response<Data.Destination.ViewModel.DestinationViewModel> destination = await _service.Get(id);
        ViewBag.Destination = destination.Data;
        List<int> DestinationCategoriesList = destination.Data?.Categories?.Select(category => category.Id)?.ToList() ?? [];
        return View(new CategoryDestinationDto()
        {
            DestinationId = id,
            DestinationCategoriesList = DestinationCategoriesList,
            DestinationCategories = DestinationCategoriesList.Count != 0 ? string.Join(",", DestinationCategoriesList) : string.Empty
        });
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [AdminActionFilter]
    public async Task<IActionResult> Categories(CategoryDestinationDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = await _service.DestinationCategoryInsertUpdate(dto);
            if (result.IsSuccess && result.Data)
            {
                return AreaRedirectToAction("Destinations", nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        ViewBag.Categories = await _listService.Categories();
        Response<Data.Destination.ViewModel.DestinationViewModel> destination = await _service.Get(dto.DestinationId);

        ViewBag.Destination = destination.Data;
        return View(dto);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.DestinationTypes = await _listService.DestinationTypes();

        return View(new CreateDestinationDto() { Title = string.Empty });
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(CreateDestinationDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = await _service.Create(dto);
            if (result.IsSuccess)
            {
                return AreaRedirectToAction("Destinations", nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        ViewBag.DestinationTypes = await _listService.DestinationTypes(dto.DestinationTypeId);

        return View(dto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        Response<Data.Destination.ViewModel.DestinationViewModel> destination = await _service.Get(id);
        if (!destination.IsSuccess || destination.Data is null)
        {
            return InternalServerErrorError(destination.Message);
        }

        ViewBag.DestinationTypes = await _listService.DestinationTypes(destination.Data.DestinationTypeId);

        return View(_mapper.Map<UpdateDestinationDto>(destination.Data));
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Edit(UpdateDestinationDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = await _service.Update(dto);
            if (result.IsSuccess)
            {
                return AreaRedirectToAction("Destinations", nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        ViewBag.DestinationTypes = await _listService.DestinationTypes(dto.DestinationTypeId);

        return View(dto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        Response<Data.Destination.ViewModel.DestinationViewModel> destination = await _service.Get(id);
        if (!destination.IsSuccess || destination.Data is null)
        {
            return InternalServerErrorError(destination.Message);
        }

        _ = await _service.Delete(id);
        return AreaRedirectToAction("Destinations", nameof(Index));
    }
}
