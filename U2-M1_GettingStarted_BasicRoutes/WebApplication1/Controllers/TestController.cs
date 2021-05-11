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
        [Route("/basicstringroute")]
        public string BasicStringAction()
        {
            return "Test response";
        }

        [Route("/basicintroute")]
        public int BasicIntAction()
        {
            return 100;
        }
    }
}
