using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Trizen.Data.User.ViewModel;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.Areas.User.Controllers;

[Authorize]
[Area("User")]
public class BaseController<C> : Controller
{
    protected ILogger<C> _logger;

    protected ActionResult AreaRedirectToAction(string controller, string? action = null, Dictionary<string, string>? parameters = null)
    {
        string link = $"/User/{controller}/{action}";
        int parameterCounter = 0;
        if (parameters != null)
        {
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                parameterCounter++;
                if (parameter.Key.Equals("id", StringComparison.CurrentCultureIgnoreCase))
                {
                    link += $"/{parameter.Value}";
                }
                else if (parameterCounter == 1)
                {
                    link += $"?{parameter.Key}={parameter.Value}";
                }
                else
                {
                    link += $"&{parameter.Key}={parameter.Value}";
                }
            }
        }
        return LocalRedirect(link);
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
            new Claim(IdentityClaims.BirthDate, StringExtensions.Coalesce(user.BirthDay?.ToString())),
            new Claim(IdentityClaims.Role, StringExtensions.Coalesce(user.Role.ToInt().ToString())),
            new Claim(IdentityClaims.ProfileImage, StringExtensions.Coalesce(user.ImageProfile)),
            new Claim(IdentityClaims.IsProfileCompleted, StringExtensions.Coalesce(user.IsProfileCompleted.ToString())),
            new Claim(IdentityClaims.Personality, StringExtensions.Coalesce(user.PersonalityId.ToString()))
        ];

        ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }

    protected ActionResult NotFoundError(string? message = null)
    {
        _logger.LogError("{ErrorType}: {Message}", nameof(NotFoundError), message);
        return RedirectToAction("NotFound", "Error", new { message });
    }

    protected ActionResult InternalServerErrorError(string? message = null)
    {
        _logger.LogError("{ErrorType}: {Message}", nameof(InternalServerErrorError), message);
        return RedirectToAction("InternalServerErrorError", "Error", new { message });
    }
}