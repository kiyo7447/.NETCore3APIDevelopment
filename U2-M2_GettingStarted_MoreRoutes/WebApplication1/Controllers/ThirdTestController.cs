using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("httpmethodroutes")]
    public class ThirdTestController : Controller
    {
        [HttpGet]
        public string Action_GET()
        {
            return "get method";
        }

        [HttpPost]
        public string Action_POST()
        {
            return "post method";
        }

        [HttpPut]
        public string Action_PUT()
        {
            return "put method";
        }

        [HttpDelete]
        public string Action_DELETE()
        {
            return "delete method";
        }
    }
}
