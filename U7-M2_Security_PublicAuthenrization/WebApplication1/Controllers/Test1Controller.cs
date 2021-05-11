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
    public class Test1Controller : Controller
    {
        public int DataRetrievalAction1()
        {
            return 100;
        }

        public string DataRetrievalAction2()
        {
            return "test data";
                
        }

        public List<string> DataRetrievalAction3()
        {
            return new List<string>() { "test 1", "test 2", "test 3", "test 4" };
        }
    }
}
