using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class CountryEncoder
    {
        public static string NameToCode(string name)
        {
            switch (name)
            {
                case "germany":
                    return "GE";
                case "united kingdom":
                    return "UK";
                case "France":
                    return "FR";
                default:
                    return ""; 
            }
        }

        public static string NameToIP(string name)
        {
            switch (name)
            {
                case "germany":
                    return "164.22.22.22";
                case "united kingdom":
                    return "167.22.22.22";
                case "France":
                    return "163.22.22.22";
                default:
                    return "";
            }
        }
    }
}
