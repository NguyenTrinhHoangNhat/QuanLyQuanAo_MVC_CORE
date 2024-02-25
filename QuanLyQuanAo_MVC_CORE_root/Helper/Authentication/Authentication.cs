using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuanLyQuanAo_MVC_CORE.Helper.Authentication
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string userId = context.HttpContext.Session.GetString("UserId");

            if (userId == null )
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller","Account"},
                        {"Action","Login" }
                    }
                );
            }
            if (context.HttpContext.Session.GetString("Role") == "Customer")
            {
                var currentPath = context.HttpContext.Request.Path.Value;

                if (currentPath.StartsWith("/Admin/"))
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                {"controller","Home"},
                {"Action","Index" }
                        }
                    );
                }
            }
        }
    }
}
