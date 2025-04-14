using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Destination.Dto;
using Trizen.Data.Destination.ViewModel;
using Trizen.Data.User.Dto;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Controllers
{
    public class DestinationsController : BaseController<DestinationsController>
    {
        private readonly IDestinationService _destinationService;
        private readonly IUserService _userService;
        private readonly IListService _listService;

        public DestinationsController(ILogger<DestinationsController> logger, IDestinationService destinationService, IUserService userService, IListService listService)
        {
            _logger = logger;
            _destinationService = destinationService;
            _userService = userService;
            _listService = listService;
        }

        public async Task<IActionResult> Index(SearchDestinationDto model)
        {
            model.UserId = User.GetUserId();
            ListResponse<DestinationViewModel> data = await _destinationService.GetAll(model);
            model.Destinations = data.Data;
            ViewBag.DestinationTypes = await _listService.DestinationTypes(model.DestinationTypeId);

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id.IsNotZeroOrNull())
            {
                int userId = User.GetUserId();
                Response<DestinationViewModel> destination = await _destinationService.GetById(id, userId);
                if (destination.Data is not null && User.Identity.IsAuthenticated)
                {
                    await _userService.VisitDestination(new LikeDestinationDto
                    {
                        ObserveType = ObserveType.Visit,
                        DestinationId = id,
                        UserId = userId
                    });

                    return View(destination.Data);
                }
            }

            return NotFoundError(Message.Format(Message.EntityNotFound, Resource.Destination));
        }
    }
}
