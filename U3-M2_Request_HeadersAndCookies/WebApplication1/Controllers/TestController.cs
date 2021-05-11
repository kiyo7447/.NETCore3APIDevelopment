using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        [Route("api/test1")]
        public string Test1()
        {
            string testcookie = Request.Cookies["testcookie"];
            string testheader = Request.Headers["testheader"];
            return testcookie +  " " + testheader;
        }

        [Route("api/test2")]
        public string Test2()
        {
            Response.Cookies.Append("newcookie", "cookie value", new Microsoft.AspNetCore.Http.CookieOptions() {  Expires = DateTime.UtcNow.AddDays(30) });
            Response.Headers.Add("newheader", "header value");
            return "";
        }
    }
}
