using System;
using System.Collections.Generic;

namespace Common.Helpers
{
    public class UuidHelper
    {
        public static string GenerateUniqueKey(int length)
        {
            if (length < 16)
            {
                length = 16;
            }
            var key = $"{(DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds * 100).ToString("F0")}";
            key = key.PadLeft(16, '0');

            List<char> chars = new List<char>(length);
            for (int i = 0; i < key.Length; i++)
            {
                chars.Insert(i, key[i]);
            }

            string randomChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = chars.Count; i < length; i++)
            {
                chars.Insert(i, randomChars[random.Next(0, randomChars.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
