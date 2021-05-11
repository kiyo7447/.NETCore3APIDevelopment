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
        [Route("test1")]
       public IActionResult test1()
        {
            return Ok();
        }

        [Route("test2")]
        public IActionResult test2()
        {
            return BadRequest("Something went wrong");
        }

        [Route("test3")]
        public string test3()
        {

            Response.StatusCode = 304;
            return "test";
        }
    }
}
