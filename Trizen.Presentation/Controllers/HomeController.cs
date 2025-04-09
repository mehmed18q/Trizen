using Microsoft.AspNetCore.Mvc;

namespace Trizen.Presentation.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
