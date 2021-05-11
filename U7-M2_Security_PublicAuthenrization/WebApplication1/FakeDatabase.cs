using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class FakeDatabase
    {
        public static List<appdata> apps = new List<appdata>()
        {
            new appdata()
            {
                appid = "a1",
                appsecret = "12345",
                scopes = "Test1,Test2"
            },
            new appdata()
            {
                appid = "a2",
                appsecret = "12345",
                scopes = "Test1,Test3"
            },
            new appdata()
            {
                appid = "a3",
                appsecret = "12345",
                scopes = "Test2"
            },
            new appdata()
            {
                appid = "a4",
                appsecret = "12345",
                scopes = "Test2,Test3"
            }

        };
        public class appdata
        {
            public string appid { get; set; }
            public string appsecret { get; set; }
            public string scopes { get; set; }
        }
    }
}
