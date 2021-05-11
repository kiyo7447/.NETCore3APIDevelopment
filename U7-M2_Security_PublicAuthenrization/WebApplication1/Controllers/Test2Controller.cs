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
    public class Test2Controller : Controller
    {
        public bool DataRetrievalAction1()
        {
            return true;
        }

        public string DataRetrievalAction2()
        {
            return "test data 3";

        }
    }
}
