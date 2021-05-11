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
        private readonly TestService _testService;
       public  TestController(TestService testService)
        {
            _testService = testService;
        }

        [Route("testroute")]
        public string TestRoute()
        {
            return _testService.ReturnString();
        }
    }
}
