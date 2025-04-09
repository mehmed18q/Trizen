using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.User.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Areas.User.Controllers;


public class ProfileController : BaseController<ProfileController>
{
    private readonly IUserService _service;
    private readonly IListService _listService;

    public ProfileController(ILogger<ProfileController> logger, IUserService service, IListService listService)
    {
        _logger = logger;
        _service = service;
        _listService = listService;
    }

    public async Task<IActionResult> Panel()
    {
        int userId = User.GetUserId();
        (bool, bool, bool) profileStatus = await _service.CheckProfileStatus(userId);
        (int, int, int, int) siteStatus = await _service.GetSiteStatus();
        UserPanelViewModel model = new()
        {
            FullName = User.GetFullName(),
            IsImportantProfileCompleted = profileStatus.Item1,
            IsProfileCompleted = profileStatus.Item2,
            HaveTravel = profileStatus.Item3,
            UserId = userId,
            UsersCounts = siteStatus.Item1,
            ToursCounts = siteStatus.Item2,
            DestinationsCounts = siteStatus.Item3,
            TravelsCounts = siteStatus.Item4,
        };
        return View(model);
    }

    public async Task<IActionResult> Edit()
    {
        Response<UpdateProfileDto> result = await _service.GetProfile(User.GetUserId());
        if (result.IsSuccess)
        {
            ViewBag.Personalities = await _listService.Personalities(result.Data!.PersonalityId);

            return View(result.Data);
        }
        return NotFoundError(result.Message);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Edit(UpdateProfileDto dto)
    {
        if (ModelState.IsValid)
        {
            dto.Id = User.GetUserId();
            Response<ProfileViewModel> result = await _service.EditProfile(dto);
            if (result.IsSuccess)
            {
                _ = LoginUser(result.Data);
                return AreaRedirectToAction("Profile", nameof(Panel));
            }
            else
            {
                ModelState.AddModelError("", result.Message!);
            }
        }

        return View(dto);
    }
}
