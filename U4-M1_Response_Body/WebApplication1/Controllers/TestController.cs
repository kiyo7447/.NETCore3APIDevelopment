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
        public class testresponsemodel
        {
            public string val1 { get; set; }
            public int val2 { get; set; }
        }
        [Route("test1")]
        public testresponsemodel test1()
        {
            return new testresponsemodel() { val1 = "test value 1", val2 = 100 };
        }


        [Route("test2")]
        public string test2()
        {
            return "test";
        }


        [Route("test3")]
        public FileStreamResult test3()
        {
            var mstr = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes("test text")); 
            return new FileStreamResult(mstr, "file/text");
        }
    }
}
