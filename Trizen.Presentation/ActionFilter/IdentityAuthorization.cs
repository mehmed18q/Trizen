using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Presentation.ActionFilter;

[AttributeUsage(AttributeTargets.All)]
public class AdminActionFilter : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.User.CheckRole(UserRoles.Admin))
        {
            context.Result = new RedirectToActionResult("ForbiddenError", "Error", null);
            return;
        }

        // Call the next delegate/middleware in the pipeline
        _ = await next();
    }
}
