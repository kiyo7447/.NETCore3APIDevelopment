using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAuthentication
{
   public class RegistrationObject
    {
        public bool Success { get; internal set; }
        public bool PasswordError { get; internal set; }
        public int EmailError { get; internal set; }
        public int Error { get; internal set; }
    }
}
