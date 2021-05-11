using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PublicAuthorizeService
    {
        public static bool VerifyIdANDSecret(string appid, string secret)
        {
            return FakeDatabase.apps.Exists(x => x.appid == appid && x.appsecret == secret);
        }

        public static bool VerifyScopes(string appid, string scope)
        {
            return FakeDatabase.apps.Exists(x => x.appid == appid && x.scopes.Contains(scope));
        }
    }
}
