using System.Security.Cryptography;
using System.Text;

namespace Common.Helpers
{
    public static class HashHelper
    {
        public static byte[] Hash(string stringToHash)
        {
            if (!string.IsNullOrEmpty(stringToHash))
            {
                byte[] buffer = Encoding.Default.GetBytes(stringToHash);
                using (var cryptoTransformSHA1 = new SHA1CryptoServiceProvider())
                {
                    return cryptoTransformSHA1.ComputeHash(buffer);
                }
            }
            return null;
        }
    }
}
