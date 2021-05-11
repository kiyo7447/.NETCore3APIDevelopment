using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class Test2Controller : Controller
    {
        [Route("test2/action1")]
        public string Action1([FromQuery]string val1, [FromQuery]int val2)
        {
            return val1 + " " + val2;
        }


        [Route("test2/action2")]
        public string Action2([FromForm]string val1, [FromForm]int val2)
        {
            return val1 + " " + val2;
        }


        public class TestObject
        {
            public string val1 { get; set; }
            public int val2 { get; set; }
            public double val3 { get; set; }
        }

        [Route("test2/action3")]
        public string Action3([FromBody]TestObject obj)
        {
             
            return obj.val1 +";" + obj.val2+";" + obj.val3;
        }
    }
}
