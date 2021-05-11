using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomAuthentication
{
    public class Register
    {
        private readonly System.Data.SqlClient.SqlConnection _sqlconnection;
        private readonly System.Data.SqlClient.SqlConnection _sqlconnection2;

        private readonly string _emailorigin;
        private readonly string _emailfrom;
        private readonly string _emailpassword;
        private readonly int _emailport;
        public Register(string emailorigin, string emailfrom,
            string emailpassword, int emailport,
            System.Data.SqlClient.SqlConnection sqlconnection, System.Data.SqlClient.SqlConnection sqlconnection2)
        {
            _emailorigin = emailorigin;
            _emailfrom = emailfrom;
            _emailpassword = emailpassword;
            _emailport = emailport;

            _sqlconnection = sqlconnection;
            _sqlconnection2 = sqlconnection2;
        }

        public async Task<RegistrationObject> CreateAsync(string email, string password)
        {
            var output = new RegistrationObject();
            object[] verification = await Task.WhenAll<object>(VerifyEmailAsync(email),VerifyPasswordAsync(password));

            if ((int)verification[0] != 1 || (bool)verification[1])
            {
                output.Success = false;
                output.EmailError = (int)verification[0] != 1 ? 3 : (int)verification[0];
                output.PasswordError = (bool)verification[1];
                return output;
            }

            string[] salts = await Task.WhenAll(CreateSaltAsync(), CreateSaltAsync());
            byte[] hash;
            string user;

            try
            {
                hash = await HashPasswordAsync(password, salts[0], salts[1]);
            }
            catch (Exception)
            {
                output.Success = false;
                return output;
            }

            try
            {
                user = await InsertUserCredentialsAsync(email,hash);
            }
            catch (Exception e)
            {
                output.Success = false;
                return output;
            }

            bool[] insertion = await Task.WhenAll(InsertSalt1Async(user, salts[0]), InsertSalt2Async(user, salts[1]));

            if (!insertion[0] || !insertion[1])
            {
                output.Error = 4;
                return output;

            }

            output.Success = true;
            return output;
        }

        private async Task<byte[]> HashPasswordAsync(string pass,string salt1, string salt2)
        {
            byte[] buffer = Encoding.UTF32.GetBytes(salt1 + pass + salt2);
            var hmac = new HMACSHA512(buffer);
            return hmac.ComputeHash(buffer, 0, buffer.Length);
        }

        private async Task<string> CreateSaltAsync()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            var hmac = new HMACSHA512(buffer);
            return Convert.ToBase64String(hmac.ComputeHash(buffer, 0, buffer.Length), Base64FormattingOptions.None);
        }

        private async Task<bool> InsertSalt1Async(string user, string salt)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("INSERT_salt1", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", user);
                cmd.Parameters.AddWithValue("slt", Convert.FromBase64String(salt));
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> InsertSalt2Async(string user, string salt)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("INSERT_salt2", _sqlconnection2);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", user);
                cmd.Parameters.AddWithValue("slt",Convert.FromBase64String(salt));
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<object> VerifyEmailAsync(string email)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("VERIFY_email", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("em", email);
                return (int)(await cmd.ExecuteScalarAsync());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private async Task<object> VerifyPasswordAsync(string password)
        {
            return password.Length >= 6;
        }

        private async Task<string> InsertUserCredentialsAsync(string email, byte[] password)
        {
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("INSERT_usercredentials", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("em", email);
                cmd.Parameters.AddWithValue("hs", password);
                return (await cmd.ExecuteScalarAsync()).ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private async Task<string> InsertConfirmationAsync(string user, string email)
        {
            try
            {
                string confirmationtoken = await CreateSaltAsync();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("INSERT_confirmation", _sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tk", confirmationtoken);
                cmd.Parameters.AddWithValue("uid", user);
                cmd.Parameters.AddWithValue("em", email);
                await cmd.ExecuteNonQueryAsync();
                return confirmationtoken;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private async Task<bool> SendConfirmationAsync(string toemail,string token)
        {
            try
            {
                string messagebody = "tst";
                MailMessage message = new MailMessage(_emailfrom, toemail, "confirmation", messagebody);
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(_emailorigin, _emailport);
                client.Credentials = new System.Net.NetworkCredential(_emailfrom, _emailpassword);
                client.Timeout = 100;

                client.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
