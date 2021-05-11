using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAuthentication
{
    public class AuthorizeObject
    {
        public bool Authorized { get; internal set; }

        public string id { get; internal set; }
    }
}
