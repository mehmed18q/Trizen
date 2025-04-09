using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Trizen.Presentation.Controllers;
using Trizen.Application.Interfaces;
using Trizen.Data.User.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        private readonly IUserService _service;
        public AccountController(ILogger<AccountController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Login(string? returnUrl = null)
        {
            LoginUserDto model = new()
            {
                UserName = string.Empty,
                Password = string.Empty,
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            if (ModelState.IsValid)
            {
                Response<ProfileViewModel> result = await _service.Login(dto);
                if (result.IsSuccess)
                {
                    await LoginUser(result.Data!);
                    return RedirectToHome(dto.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError(nameof(dto.UserName), result.Message!);
                }
            }

            return View(dto);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            if (ModelState.IsValid)
            {
                Response<ProfileViewModel> user = await _service.Register(dto);
                if (user.IsSuccess)
                {
                    await LoginUser(user.Data!);
                    return RedirectToHome(dto.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError(nameof(dto.UserName), user.Message!);
                }
            }

            return View(dto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToHome();
        }

        [HttpPost]
        public async Task<Response<string>> LikeTour(int tourId)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userId = User.GetUserId();
                Response<string> result = await _service.LikeTour(new LikeTourDto
                {
                    UserId = userId,
                    TourId = tourId,
                    IsLiked = true,
                    ObserveType = ObserveType.Like
                });

                return result;
            }
            return Response<string>.FailResult(Message.YouAreNotLogin, Message.YouAreNotLogin);
        }
    }
}
