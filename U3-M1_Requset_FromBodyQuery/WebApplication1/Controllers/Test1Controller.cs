using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class Test1Controller : Controller
    {
        [Route("test1/action1")]
         public string Action1()
        {
            return Request.Form["val1"] + " " + Request.Form["val2"];
        }

        [Route("test1/action2")]
        public string Action2()
        {
            return Request.Query["val1"] + " " + Request.Query["val2"];
        }


        [Route("test1/action3")]
        public async Task<string> Action3()
        {
            byte[] bt = new byte[(int)Request.ContentLength];
            await Request.Body.ReadAsync(bt, 0, (int)Request.ContentLength);
            return System.Text.Encoding.UTF8.GetString(bt);
        }
    }
}
