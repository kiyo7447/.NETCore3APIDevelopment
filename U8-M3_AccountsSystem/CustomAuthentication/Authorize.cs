using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomAuthentication
{
    public class Authorize
    {
        private readonly System.Data.SqlClient.SqlConnection _sqlconnection;

        public Authorize(System.Data.SqlClient.SqlConnection sqlconnection)
        {
            _sqlconnection = sqlconnection;
        }

        public AuthorizeObject StartAuthorize(string token)
        {
            var authorizationobject = new AuthorizeObject();
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("VERIFY_token", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("tk", token);
                authorizationobject.id = (cmd.ExecuteScalar()).ToString();
                authorizationobject.Authorized = authorizationobject.id  != "";
                return authorizationobject;
            }
            catch (Exception ex)
            {
                return authorizationobject;
            }
        }
    }
}
