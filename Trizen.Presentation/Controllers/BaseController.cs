using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Trizen.Data.User.ViewModel;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Controllers
{
    public class BaseController<C> : Controller
    {
        protected ILogger<C> _logger;

        protected ActionResult RedirectToHome(string? returnUrl = null)
        {
            return returnUrl.IsNotEmpty() ? LocalRedirect(returnUrl!) : RedirectToAction("Index", "Home");
        }

        protected async Task LoginUser(ProfileViewModel user)
        {
            List<Claim> claims =
            [
                new Claim(IdentityClaims.UserName, user.UserName!),
                new Claim(IdentityClaims.FullName, user.FullName!),
                new Claim(IdentityClaims.UserId, user.Id.ToString()),
                new Claim(IdentityClaims.Email, StringExtensions.Coalesce(user.Email)),
                new Claim(IdentityClaims.MobilePhone, StringExtensions.Coalesce(user.PhoneNumber)),
                new Claim(IdentityClaims.DateOfBirth, StringExtensions.Coalesce(user.BirthDay?.ToString())),
                new Claim(IdentityClaims.Role, StringExtensions.Coalesce(user.Role.ToInt().ToString())),
                new Claim(IdentityClaims.ProfileImage, StringExtensions.Coalesce(user.ImageProfile))
            ];

            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        protected ActionResult NotFoundError(string? message = null)
        {
            _logger.LogError("{ErrorType}: {Message}", nameof(NotFoundError), message);
            return RedirectToAction("NotFoundError", "Error", new { message });
        }

        protected ActionResult InternalServerErrorError(string? message = null)
        {
            _logger.LogError("{ErrorType}: {Message}", nameof(InternalServerErrorError), message);
            return RedirectToAction("InternalServerErrorError", "Error", new { message });
        }
    }
}
