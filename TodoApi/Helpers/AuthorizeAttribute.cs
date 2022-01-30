namespace DataPapi.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DataPapi.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (User)context.HttpContext.Items["User"];
        if (user == null)
        {
            // login failed
            context.Result = new JsonResult(new { message = "Please authorize before using this API endopoint by submitting a request at endpoint /users/authenticate." }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}