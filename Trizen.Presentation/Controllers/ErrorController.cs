using Microsoft.AspNetCore.Mvc;
using System.Net;
using Trizen.Data.Base.ViewModel;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Controllers
{
    public class ErrorController : BaseController<ErrorController>
    {
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        public IActionResult ForbiddenError()
        {
            return View("Error", new ErrorViewModel
            {
                ErrorCode = HttpStatusCode.Forbidden.ToInt(),
                ErrorMessage = "این صفحه ممنوع است",
                Title = Resource.Forbidden
            });
        }

        public IActionResult NotFoundError()
        {
            return View("Error", new ErrorViewModel
            {
                ErrorCode = HttpStatusCode.NotFound.ToInt(),
                ErrorMessage = "این صفحه پیدا نشد",
                Title = Resource.NotFound
            });
        }

        public IActionResult BadRequestError()
        {
            return View("Error", new ErrorViewModel
            {
                ErrorCode = HttpStatusCode.BadRequest.ToInt(),
                ErrorMessage = "دیتا ارسالی نادرست است",
                Title = Resource.BadRequest
            });
        }

        public IActionResult InternalServerError()
        {
            return View("Error", new ErrorViewModel
            {
                ErrorCode = HttpStatusCode.InternalServerError.ToInt(),
                ErrorMessage = "خطای داخلی رخ داده است",
                Title = Resource.InternalServerError
            });
        }
    }
}
