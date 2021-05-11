using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi
{
    public class AuthorizeAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var authorizer = new CustomAuthentication.Authorize(Program.mainsql);
            string token = context.HttpContext.Request.Headers["Auth"];
            var authobject = authorizer.StartAuthorize(token);
            if (authobject.Authorized)
            {
                context.HttpContext.Response.Headers["UID"] = authobject.id;
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
