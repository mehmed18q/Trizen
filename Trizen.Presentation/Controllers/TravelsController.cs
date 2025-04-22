using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Base.ViewModel;
using Trizen.Data.Travel.Dto;
using Trizen.Data.Travel.ViewModel;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Controllers
{
    public class TravelsController : BaseController<TravelsController>
    {
        private readonly ITravelService _service;
        private readonly IListService _listService;

        public TravelsController(ILogger<TravelsController> logger, ITravelService service, IListService listService)
        {
            _logger = logger;
            _service = service;
            _listService = listService;
        }

        public async Task<IActionResult> Basket()
        {
            int userId = User.GetUserId();
            ListResponse<BasketViewModel> baskets = await _service.GetUserBasket(userId);
            return View(baskets.Data);
        }

        public async Task<IActionResult> AddTravel(int tourId)
        {
            int userId = User.GetUserId();
            Response<BasketViewModel> travel = await _service.Create(new CreateTravelDto
            {
                TourId = tourId,
                UserId = userId
            });
            ListResponse<ListViewModel> users = await _listService.GetUsers();
            List<int> alreadyPassengers = travel.Data?.PassengersList.Select(passenger => passenger.User.Id).ToList() ?? [];
            ViewBag.Users = users.Data.Where(user => !alreadyPassengers.Contains(user.Id));
            return View(travel.Data);
        }

        [HttpPost]
        public async Task<IActionResult> TravelPassengers(PassengerTravelDto dto)
        {
            Response<double> result = await _service.TravelPassengerInsertUpdate(dto);

            return Content(result.Data.ToString());
        }

        public async Task<IActionResult> Pay(int travelId)
        {
            _ = await _service.Pay(travelId);

            return RedirectToAction("PaymentStatus", new { travelId, type = nameof(Pay) });
        }

        public async Task<IActionResult> Cancel(int travelId)
        {
            _ = await _service.Cancel(travelId);

            return RedirectToAction("PaymentStatus", new { travelId, type = nameof(Cancel) });
        }

        public async Task<IActionResult> PaymentStatus(int travelId, string type)
        {
            Response<BasketViewModel> tourInformation = await _service.Get(travelId);
            ViewBag.Type = type;
            ViewBag.Tour = tourInformation.Data;
            return View();
        }
    }
}
