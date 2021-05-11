using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class CountryDecoderController : Controller
    {
        [Route("countrycodetoname")]
        public Task<string> DecodeFromCodeAsync([FromQuery]string countrycode)
        {
            return Task.FromResult(CountryDecoder.CodeToName(countrycode));
        }

        [Route("countryiptoname")]
        public Task<string> DecodeFromIpAsync(string countryip)
        {
            return Task.FromResult(CountryDecoder.IPToName(countryip));
        }
    }
}
