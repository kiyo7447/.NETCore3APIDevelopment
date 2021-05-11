using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        [Route("upload/file")]
        [HttpPost] 
        public async Task<string> uploadnew([FromForm]IFormFile testfile)
        {

            MemoryStream str = new MemoryStream();
            try
            {
                await testfile.CopyToAsync(str);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
            return str.Length.ToString();
        }
    }
}
