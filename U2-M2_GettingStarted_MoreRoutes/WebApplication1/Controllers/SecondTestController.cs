using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("Second/[Action]")]
    public class SecondTestController : Controller
    {
        public string Action1()
        {
            return "Second test controller - action 1";
        }
        public string Action2()
        {
            return "Second test controller - action 2";
        }
        public string Action3()
        {
            return "Second test controller - action 3";
        }
    }
}
