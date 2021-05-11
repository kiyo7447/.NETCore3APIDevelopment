using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class AuthorizeService
    {
        public bool CheckToken(string token)
        {
            return token == "testtoken";
        }
    }
}
