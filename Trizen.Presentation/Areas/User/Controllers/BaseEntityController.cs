using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Base.Dto;
using Trizen.Data.Base.ViewModel;
using Trizen.Infrastructure.Base.Response;
using Trizen.Presentation.ActionFilter;

namespace Trizen.Presentation.Areas.User.Controllers;

[AdminActionFilter]
public class BaseEntityController : BaseController<BaseEntityController>
{
    private readonly IBaseEntityService _service;
    private readonly IMapper _mapper;

    public BaseEntityController(ILogger<BaseEntityController> logger, IBaseEntityService service, IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(string entity)
    {
        ListResponse<BaseEntityViewModel> entities = entity.ToLower() switch
        {
            "category" => await _service.GetAllCategories(),
            "destinationtype" => await _service.GetAllDestinationTypes(),
            "tourtype" => await _service.GetAllTourTypes(),
            _ => new(),
        };
        ViewBag.Entity = entity;
        return View(entities.Data);
    }

    public IActionResult Create(string entity)
    {
        return View(new CreateBaseEntityDto() { Title = string.Empty, Entity = entity });
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(CreateBaseEntityDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = dto.Entity.ToLower() switch
            {
                "category" => await _service.CreateCategory(dto),
                "destinationtype" => await _service.CreateDestinationType(dto),
                "tourtype" => await _service.CreateTourType(dto),
                _ => new(),
            };

            if (result.IsSuccess)
            {
                return AreaRedirectToAction("BaseEntity", nameof(Index), new Dictionary<string, string> { { "Entity", dto.Entity } });
            }
            else
            {
                ModelState.AddModelError("Title", result.Message!);
            }
        }

        return View(dto);
    }

    public async Task<IActionResult> Edit(string entity, int id)
    {
        Response<BaseEntityViewModel> result = entity.ToLower() switch
        {
            "category" => await _service.GetCategory(id),
            "destinationtype" => await _service.GetDestinationType(id),
            "tourtype" => await _service.GetTourType(id),
            _ => new(),
        };

        if (!result.IsSuccess || result.Data is null)
        {
            return InternalServerErrorError(result.Message);
        }

        UpdateBaseEntityDto model = _mapper.Map<UpdateBaseEntityDto>(result.Data);
        model.Entity = entity;
        return View(model);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Edit(UpdateBaseEntityDto dto)
    {
        if (ModelState.IsValid)
        {
            Response<bool> result = dto.Entity.ToLower() switch
            {
                "category" => await _service.UpdateCategory(dto),
                "destinationtype" => await _service.UpdateDestinationType(dto),
                "tourtype" => await _service.UpdateTourType(dto),
                _ => new(),
            };

            if (result.IsSuccess)
            {
                return AreaRedirectToAction("BaseEntity", nameof(Index), new Dictionary<string, string> { { "Entity", dto.Entity } });
            }
            else
            {
                ModelState.AddModelError("Title", result.Message!);
            }
        }

        return View(dto);
    }

    public async Task<IActionResult> Delete(string entity, int id)
    {
        Response<BaseEntityViewModel> result = entity.ToLower() switch
        {
            "category" => await _service.GetCategory(id),
            "destinationtype" => await _service.GetDestinationType(id),
            "tourtype" => await _service.GetTourType(id),
            _ => new(),
        };
        if (!result.IsSuccess || result.Data is null)
        {
            return InternalServerErrorError(result.Message);
        }

        _ = entity.ToLower() switch
        {
            "category" => await _service.DeleteCategory(id),
            "destinationtype" => await _service.DeleteDestinationType(id),
            "tourtype" => await _service.DeleteTourType(id),
            _ => new(),
        };

        return AreaRedirectToAction("BaseEntity", nameof(Index), new Dictionary<string, string> { { "Entity", entity } });
    }
}
