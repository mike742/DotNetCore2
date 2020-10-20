using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DotNetCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            string d = "ApPlE"; // 789 654 133 000 111 222 
            // Console.WriteLine(Regex.IsMatch(d, @"^apple$", RegexOptions.IgnoreCase));

            d = "123-4567";
            Console.WriteLine(Regex.IsMatch(d, @"^\d{3}-\d{4}$"));

            d = "(204) 123-4567";
            Console.WriteLine(Regex.IsMatch(d, @"^\(\d{3}\) \d{3}-\d{4}$"));

            d = "mike.zorin@gmail.commm";
            Console.WriteLine(Regex.IsMatch(d, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"));

            d = "1324578945613245678946134865446132";
            Console.WriteLine("Digits only = " + Regex.IsMatch(d, @"^\d*$"));


            string re = @"^[ a-zA-Z0-9]*$";
            Console.WriteLine( IsValid("Robertson college 1657", re) );

            re = @"^[a-z]+$";
            // . 
            Console.WriteLine(IsValid("a", re));

            re = @"^..$";
            Console.WriteLine("for . = " + IsValid("%@", re));

            // ? 
            re = @"^[1-5]?$";
            Console.WriteLine("for ? = " + IsValid("", re));

            // var key = Console.ReadKey();

            string str = "4 and 5";

            Match m = Regex.Match(str, @"\d");

            if (m.Success)
            {
                Console.WriteLine(m.Value);
            }

            m = m.NextMatch();

            if (m.Success)
            {
                Console.WriteLine(m.Value);
            }


            str = "HELLO";
            string res = str.FlipFirstLetterCase();

            Console.WriteLine(res);


            BigInteger i = new BigInteger();
            i.ToWords();
        }

        static bool IsValid(string value, string re)
        {
            return Regex.IsMatch(value, re);
        }
    }
}
