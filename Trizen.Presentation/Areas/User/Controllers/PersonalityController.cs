using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Base.ViewModel;
using Trizen.Data.Tour.Dto;
using Trizen.Infrastructure.Base.Response;
using Trizen.Presentation.ActionFilter;

namespace Trizen.Presentation.Areas.User.Controllers;

[AdminActionFilter]
public class PersonalityController : BaseController<PersonalityController>
{
    private readonly IPersonalityService _service;
    private readonly IMapper _mapper;
    private readonly IListService _listService;

    public PersonalityController(ILogger<PersonalityController> logger, IPersonalityService service, IMapper mapper, IListService listService)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
        _listService = listService;
    }

    [AdminActionFilter]
    public async Task<IActionResult> Index()
    {
        List<Data.User.ViewModel.PersonalityViewModel> Personalities = await _service.GetPersonalities();
        return View(Personalities);
    }


    [AdminActionFilter]
    public async Task<IActionResult> Edit(int id, string entity)
    {
        ListResponse<ListViewModel> List = entity.ToLower() switch
        {
            "category" => await _listService.Categories(),
            "destinationtype" => await _listService.DestinationTypes(),
            "tourtype" => await _listService.TourTypes(),
            _ => new(),
        };

        ViewBag.List = List.Data;
        ListResponse<int> entityIds = entity.ToLower() switch
        {
            "category" => await _service.GetAllCategories(id),
            "destinationtype" => await _service.GetAllDestinationTypes(id),
            "tourtype" => await _service.GetAllTourTypes(id),
            _ => new(),
        };
        Data.User.ViewModel.PersonalityViewModel Personality = await _service.GetPersonality(id);
        return View(new UpdatePersonalityDto()
        {
            PersonalityId = id,
            EntitieIds = string.Join(",", entityIds.Data),
            Entity = entity,
            Code = Personality.Code,
            Title = Personality.Title,
            Description = Personality.Description
        });
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    [AdminActionFilter]
    public async Task<IActionResult> Edit(UpdatePersonalityDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = dto.Entity.ToLower() switch
            {
                "category" => await _service.PersonalityCategoryInsertUpdate(dto),
                "destinationtype" => await _service.PersonalityDestinationTypeInsertUpdate(dto),
                "tourtype" => await _service.PersonalityTourTypeInsertUpdate(dto),
                _ => new(),
            };

            if (result.IsSuccess && result.Data)
            {
                return AreaRedirectToAction("Personality", nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        ListResponse<ListViewModel> List = dto.Entity.ToLower() switch
        {
            "category" => await _listService.Categories(),
            "destinationtype" => await _listService.DestinationTypes(),
            "tourtype" => await _listService.TourTypes(),
            _ => new(),
        };

        ViewBag.List = List.Data;
        ViewBag.Personality = await _service.GetPersonality(dto.PersonalityId);
        return View(dto);
    }

}
