using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Celia.io.Core.MicroServices.Utilities
{
    public class HashUtils
    {
        private static MD5 _md5;
        private static SHA256 _sha256;

        static HashUtils()
        {
            _md5 = new MD5CryptoServiceProvider();
            _sha256 = SHA256.Create();
        }

        public static string GetMd5String(string sourceStr)
        {
            if (string.IsNullOrEmpty(sourceStr))
                throw new ArgumentNullException(nameof(sourceStr));
            byte[] result = Encoding.UTF8.GetBytes(sourceStr);

            byte[] output = _md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }

        public static string GetSha256String(string sourceStr)
        {
            if (string.IsNullOrEmpty(sourceStr))
                throw new ArgumentNullException(nameof(sourceStr));
            // Send a sample text to hash.  
            var hashedBytes = _sha256.ComputeHash(Encoding.UTF8.GetBytes(sourceStr));
            // Get the hashed string.  
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            // Print the string.   
            return hash;
        }

        public static string OpenApiSign(string appid, string appsecret,
            long timestamp, string content)
        {
            string combined = $"{appsecret}!@{appid}#{timestamp}&{content}";

            return GetSha256String(combined);
        }
    }
}
