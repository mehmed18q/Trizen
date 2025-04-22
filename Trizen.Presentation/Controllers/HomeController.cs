using Microsoft.AspNetCore.Mvc;
using Trizen.Application.Interfaces;
using Trizen.Data.Base.ViewModel;
using Trizen.Data.Destination.Dto;
using Trizen.Data.Destination.ViewModel;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly IDestinationService _destinationService;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, IDestinationService destinationService, IUserService userService)
        {
            _logger = logger;
            _destinationService = destinationService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = User.GetUserId();
            ListResponse<DestinationViewModel> destinations = await _destinationService.GetAll(new SearchDestinationDto
            {
                UserId = userId,
                Pagination = new Pagination
                {
                    PageNumber = 1,
                    PageSize = 10,
                }
            });
            (int, int, int, int) siteStatus = await _userService.GetSiteStatus();

            HomeViewModel model = new()
            {
                Destinations = destinations.Data,
                UsersCounts = siteStatus.Item1,
                ToursCounts = siteStatus.Item2,
                DestinationsCounts = siteStatus.Item3
            };

            return View(model);
        }

        public async Task<IActionResult> AboutUs()
        {
            (int, int, int, int) siteStatus = await _userService.GetSiteStatus();
            List<TeamViewModel> team =
            [
                new TeamViewModel{
                    FullName = "محمد صادق کیومرثی",
                    Position = "سرپرست واحد توسعه دهنده وب",
                    Email = "mehmed2002q@gmail.com",
                    Image = "/Images/User/34dac24d-3b74-47c3-9d24-55ed90e5a696__sadeq.png",
                    Instagram = "https://www.instagram.com/sadeq.dev",
                    LinkedIn = "https://www.linkedin.com/in/sadeq-kiomarsi",
                    PhoneNumber = "+989217074647",
                    Telegram = "https://telegram.org/msk18q",
                    Whatsapp = "https://wa.me/+989217074647",
                    Website ="http://sadeqkiumarsi.ir/"
                },
                new TeamViewModel{
                    FullName = "فاطمه داشخواه",
                    Image = $"/Images/User/{Resource.DefaultImage}",
                },
                new TeamViewModel{
                    FullName = "هانیه گرامی",
                    Image = $"/Images/User/{Resource.DefaultImage}",
                },
            ];

            AboutUsViewModel model = new()
            {
                Team = team,
                UsersCounts = siteStatus.Item1,
                ToursCounts = siteStatus.Item2,
                DestinationsCounts = siteStatus.Item3,
                TravelsCounts = siteStatus.Item4
            };
            return View(model);
        }
    }
}
