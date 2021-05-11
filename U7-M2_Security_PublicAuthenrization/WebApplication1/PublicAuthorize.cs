using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PublicAuthorize : Attribute, IActionFilter
    {
       
        public void OnActionExecuting(ActionExecutingContext context)
        {


            if (!PublicAuthorizeService.VerifyIdANDSecret(context.HttpContext.Request.Headers["appid"], context.HttpContext.Request.Headers["appsecret"]))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!PublicAuthorizeService.VerifyScopes(context.HttpContext.Request.Headers["appid"], context.RouteData.Values["Controller"].ToString()))
            {
                context.Result = new UnauthorizedResult();
                return;
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }



    }
}
