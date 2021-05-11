using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapi.Controllers
{
   
    public class AuthenticationController : Controller
    {
        [Route("auth")]
        public async Task<CustomAuthentication.AuthObject> reg()
        {
            System.Data.SqlClient.SqlConnection conn1 = new System.Data.SqlClient.SqlConnection(Environment.GetEnvironmentVariable("sqlconn"));
            System.Data.SqlClient.SqlConnection conn2 = new System.Data.SqlClient.SqlConnection(Environment.GetEnvironmentVariable("sqlconn"));
            await conn1.OpenAsync();
            await conn2.OpenAsync();

            var authenticator = new CustomAuthentication.Authentication(conn1,conn2);
            return await authenticator.StartAsync(Request.Query["email"], Request.Query["password"]);
        }
    }
}
