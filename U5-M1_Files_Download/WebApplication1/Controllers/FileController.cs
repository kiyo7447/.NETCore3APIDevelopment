using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        [Route("download")]
        public async Task<FileResult> getfile(string id)
        {
            byte[] testbytearray = null;
            switch (id)
            {
                case "t1":
                    testbytearray = System.Text.Encoding.UTF8.GetBytes("Text to test - t1");
                    break;
                case "t2":
                    testbytearray = System.Text.Encoding.UTF8.GetBytes("Text to test - t2");
                    break;
                default:
                    break;
            }
           
            return File(testbytearray, "application/txt", "testfile.txt");
        }
    }
}
