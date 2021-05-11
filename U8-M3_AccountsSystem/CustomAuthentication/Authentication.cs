using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomAuthentication
{

    
   public class Authentication
    {
        private readonly System.Data.SqlClient.SqlConnection _sqlconnection;
        private readonly System.Data.SqlClient.SqlConnection _sqlconnection2;
        public Authentication(System.Data.SqlClient.SqlConnection sqlconnection, System.Data.SqlClient.SqlConnection sqlconnection2)
        {
            _sqlconnection = sqlconnection;
            _sqlconnection2 = sqlconnection2;
        }

        public async Task<AuthObject> StartAsync(string email, string password)
        {
            var output = new AuthObject();

            string id = await GetIdAsync(email);

            if (id == "")
            {
                output.Error = 2;
                output.Success = false;
                return output;
            }

            string[] salts = await Task.WhenAll(GetSalt1Async(id), GetSalt2Async(id));
            byte[] hash = await HashPasswordAsync(password, salts[0], salts[1]);

            bool passcheck = await CheckPasswordAsync(id, hash);

            if (passcheck)
            {
                output.Token = await CreateTokenAsync(id);
                output.Id = id;
                output.Success = true;
                return output;
            }
            else
            {
                output.Error = 3;
                output.Success = false;
                return output;
            }
        }

        private async Task<string> GetIdAsync(string email)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GET_idbyemail", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("em", email);
                return (await cmd.ExecuteScalarAsync()).ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private async Task<string> GetSalt1Async(string id)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GET_salt1", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("uid", id);
                return  Convert.ToBase64String((byte[])await cmd.ExecuteScalarAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<string> GetSalt2Async(string id)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GET_salt2", _sqlconnection2);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("uid", id);
                return Convert.ToBase64String((byte[])await cmd.ExecuteScalarAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<byte[]> HashPasswordAsync(string pass, string salt1, string salt2)
        {
            byte[] buffer = Encoding.UTF32.GetBytes(salt1 + pass + salt2);
            var hmac = new HMACSHA512(buffer);
            return hmac.ComputeHash(buffer, 0, buffer.Length);
        }

        private async Task<bool> CheckPasswordAsync(string id, byte[] hash)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GET_hash", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("uid", id); 
                byte[] output = (byte[])(await cmd.ExecuteScalarAsync());
                return Convert.ToBase64String(output) == Convert.ToBase64String(hash);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<string> CreateTokenAsync(string id)
        {
            try
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                var hmac = new HMACSHA512(buffer);
                string token = Convert.ToBase64String(hmac.ComputeHash(buffer,0,buffer.Length));

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("INSERT_token", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("uid",id);
                cmd.Parameters.AddWithValue("tk",token);

                await cmd.ExecuteNonQueryAsync();
                return token;

            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }

    


}
