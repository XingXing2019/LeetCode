using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestFairInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 99999999;
            Console.WriteLine(ClosestFair(n));
        }

        public static int ClosestFair(int n)
        {
            if (IsFair(n))
                return n;
            var digits = n.ToString().Length;
            if (digits % 2 == 0) 
                return ClosestFair(n + 1);
            var res = $"1{new string('0', digits / 2 + 1)}{new string('1', digits / 2)}";
            return int.Parse(res);
        }

        private static bool IsFair(int n)
        {
            var even = n.ToString().Count(x => x % 2 == 0);
            return even == n.ToString().Length - even;
        }
    }
}
