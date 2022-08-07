using System;
using System.Collections.Generic;

namespace NumberOfArithmeticTriplets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int ArithmeticTriplets(int[] nums, int diff)
        {
            var dict = new Dictionary<int, int>();
            var res = 0;
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num - diff) && dict.ContainsKey(num - 2 * diff))
                    res += dict[num - diff] * dict[num - 2 * diff];
                dict[num] = dict.GetValueOrDefault(num, 0) + 1;
            }
            return res;
        }
    }
}
