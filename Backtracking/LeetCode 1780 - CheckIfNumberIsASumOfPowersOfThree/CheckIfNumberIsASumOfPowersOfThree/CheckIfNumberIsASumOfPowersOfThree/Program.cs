using System;
using System.Collections.Generic;

namespace CheckIfNumberIsASumOfPowersOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;
            Console.WriteLine(CheckPowersOfThree(n));
        }

        public static bool CheckPowersOfThree(int n)
        {
            while (n != 0)
            {
                if (n % 3 == 2) return false;
                n /= 3;
            }
            return true;
        }
    }
}
