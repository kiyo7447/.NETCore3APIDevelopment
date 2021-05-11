using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Authorize : Attribute, IActionFilter
    {

        AuthorizeService authorizer = new AuthorizeService();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers["Auth"] == "")
            {
                context.Result = new UnauthorizedResult();

            }
           
            if (authorizer.CheckToken(context.HttpContext.Request.Headers["Auth"]))
            {
                
            }
            else
            {
                context.Result = new UnauthorizedResult();

            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var output = context.Result;
        }



    }
}
