using System;
using System.Collections.Generic;

namespace MinimumImpossibleOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinImpossibleOR(int[] nums)
        {
            var set = new HashSet<int>(nums);
            var res = 1;
            while (set.Contains(res))
                res <<= 1;
            return res;
        }
    }
}
