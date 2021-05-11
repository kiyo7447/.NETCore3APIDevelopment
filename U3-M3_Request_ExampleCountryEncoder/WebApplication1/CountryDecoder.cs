using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class CountryDecoder
    {
        


    public static string CodeToName(string countrycode)
    {
            switch (countrycode)
            {
                case "GE":
                    return "germany";
                case "UK":
                    return "united kingdom";
                case "FR":
                    return "france";
                default:
                    return "";
            }
        }

    public static string IPToName(string ip)
    {
        switch (ip)
        {
            case "164.22.22.22":
                return "germany";
            case "167.22.22.22":
                return "united kingdom";
            case "163.22.22.22":
                return "france";
            default:
                return "";
        }
    }
}
}
