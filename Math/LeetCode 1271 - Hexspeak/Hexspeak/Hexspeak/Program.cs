using System;
using System.Collections.Generic;

namespace Hexspeak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string ToHexspeak(string num)
        {
            string dict = "OI23456789ABCDEF";
            var inValid = new List<long> {2, 3, 4, 5, 6, 7, 8, 9};
            var hex = "";
            long number = long.Parse(num);
            while (number != 0)
            {
                var digit = number % 16;
                if (inValid.Contains(digit))
                    return "ERROR";
                hex = dict[(int)digit] + hex;
                number /= 16;
            }
            return hex;
        }
    }
}
