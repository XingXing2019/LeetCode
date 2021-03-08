using System;
using System.Collections.Generic;

namespace StrobogrammaticNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsStrobogrammatic(string num)
        {
            var dict = new Dictionary<char, char>
            {
                {'0', '0'},
                {'1', '1'},
                {'6', '9'},
                {'8', '8'},
                {'9', '6'}
            };
            int li = 0, hi = num.Length - 1;
            while (li <= hi)
            {
                if (!dict.ContainsKey(num[li]) || dict[num[li]] != num[hi])
                    return false;
                li++;
                hi--;
            }
            return true;
        }
    }
}

