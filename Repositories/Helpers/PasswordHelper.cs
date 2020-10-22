using System;
using System.Collections.Generic;

namespace Repositories.Helpers
{
    public class PasswordHelper
    {
        public static string GenerateRandomPassword(int length, bool requireDigit, bool requireNonAlphanumeric)
        {
            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789",    // all 
                "0123456789",                   // digits
                "!@$?_-"                        // non-alphanumeric
            };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>(length);

            string rcs = randomChars[0];
            for (int i = chars.Count; i < length; i++)
            {
                chars.Insert(i, rcs[rand.Next(0, rcs.Length)]);
            }

            if (requireDigit)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);
            }

            if (requireNonAlphanumeric)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
