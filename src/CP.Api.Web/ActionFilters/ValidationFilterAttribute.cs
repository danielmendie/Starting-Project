using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CP.Api.Web.ActionFilters;

/// <summary>
///Action filter that validates model class sent on post requests
/// </summary>
public class ValidationFilterAttribute : IActionFilter
{
    /// <summary>
    ///ValidationFilterAttribute Constructor
    /// </summary>
    public ValidationFilterAttribute()
    { }

    /// <summary>
    ///OnEexecuting filter
    /// </summary>
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().EndsWith("DTO")).Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        if (param is null)
        {
            context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
            return;
        }

        if (!context.ModelState.IsValid)
        {
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }

    /// <summary>
    ///OnActionexecuted filter
    /// </summary>
    public void OnActionExecuted(ActionExecutedContext context)
    { }
}
