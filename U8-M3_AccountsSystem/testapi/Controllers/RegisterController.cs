using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapi.Controllers
{
   
    public class RegisterController : Controller
    {
        [Route("register")]
        public async Task<CustomAuthentication.RegistrationObject> reg()
        {
            System.Data.SqlClient.SqlConnection conn1 = new System.Data.SqlClient.SqlConnection(Environment.GetEnvironmentVariable("sqlconn"));
            System.Data.SqlClient.SqlConnection conn2 = new System.Data.SqlClient.SqlConnection(Environment.GetEnvironmentVariable("sqlconn"));
            await conn1.OpenAsync();
            await conn2.OpenAsync();

            var registrator = new CustomAuthentication.Register("", "", "", 0,conn1,conn2);
            return await registrator.CreateAsync(Request.Form["email"],Request.Form["password"]);
        }
    }
}
