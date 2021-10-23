using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace CommonModel
{
    public class Utils
    {
        private static string _secretCode = "<MND!%$%#%$FH(*W$ONMNFSFPW$REWFDS";
        public static string PasswordHash(string password)
        {
            return HmacSha256Digest(password, _secretCode);
        }
        private static string HmacSha256Digest(string message, string secret)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);

            byte[] bytes = cryptographer.ComputeHash(messageBytes);

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
