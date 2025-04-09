using Microsoft.AspNetCore.Mvc;
using Trizen.Presentation.Controllers;
using Trizen.Application.Interfaces;
using Trizen.Data.Tour.ViewModel;
using Trizen.Data.User.Dto;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Controllers
{
    public class ToursController : BaseController<ToursController>
    {
        private readonly ITourService _tourService;
        private readonly IUserService _userService;

        public ToursController(ILogger<ToursController> logger, ITourService tourService, IUserService userService)
        {
            _logger = logger;
            _tourService = tourService;
            _userService = userService;
        }

        public IActionResult Index(SearchTourViewModel model)
        {
            model.CallerPage = CallerPage.Search;
            model.UserId = User.GetUserId();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id.IsNotZeroOrNull())
            {
                int userId = User.GetUserId();
                Response<TourViewModel> tour = await _tourService.Get(id, userId);
                if (tour.Data is not null)
                {
                    await _userService.VisitTour(new LikeTourDto
                    {
                        ObserveType = ObserveType.Visit,
                        TourId = id,
                        UserId = userId
                    });

                    return View(tour.Data);
                }
            }

            return NotFoundError(Message.Format(Message.EntityNotFound, Resource.Tour));
        }
    }
}
