using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[Controller]/[Action]")]
    [PublicAuthorize]
    public class Test3Controller : Controller
    {
        public string DataRetrievalAction1()
        {
            return "test data 5";

        }

        public double DataRetrievalAction2()
        {
            return 1.56666;
        }
    }
}
