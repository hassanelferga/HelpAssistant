using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HelpAssistant.Api.Web.Utils
{
    public static class Crypto
    {
        public static string HashString(string plainString)
        {
            // Convert string to array of bytes to be used in the hash
            var data = Encoding.ASCII.GetBytes(plainString);
            var sha1 = new SHA1CryptoServiceProvider();
            var hashedData = sha1.ComputeHash(data);

            string hashString = Convert.ToBase64String(hashedData);
            return hashString;
        }

        internal static long HashString(long userID)
        {
            throw new NotImplementedException();
        }
    }
}