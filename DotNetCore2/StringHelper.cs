using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DotNetCore2
{
    public static class StringHelper
    {
        public static string FlipFirstLetterCase(this string input)
        {
            if (input.Length > 0)
            {
                char[] charArr = input.ToCharArray();

                charArr[0] = 
                    char.IsUpper(charArr[0]) ? 
                    char.ToLower(charArr[0]) : char.ToUpper(charArr[0]);

                return new string(charArr);
            }

            return input;
        }


        public static void ToWords(this BigInteger bi)
        {
            Console.WriteLine("ToWords has been invoked!");
        }
    }
}
