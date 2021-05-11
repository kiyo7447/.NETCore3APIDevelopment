using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class CountryEncoderController : Controller
    {
        [Route("nametocode")]
        public Task<string> EncodeToCodeAsync([FromQuery]string countryname)
        {
            return Task.FromResult(CountryEncoder.NameToCode(countryname));
        }

        [Route("nametoip")]
        public Task<string> EncodeToIpAsync(string ip)
        {
            return Task.FromResult(CountryEncoder.NameToIP(ip));
        }
    }
}
