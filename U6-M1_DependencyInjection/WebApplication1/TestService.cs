using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class TestService
    {
        int _int = 20;
        public int ReturnInteger()
        {
            _int++;
            return _int;
        }

        public string ReturnString()
        {
            return $"Test String:int:{_int}";
        
        
        }
    }
}
