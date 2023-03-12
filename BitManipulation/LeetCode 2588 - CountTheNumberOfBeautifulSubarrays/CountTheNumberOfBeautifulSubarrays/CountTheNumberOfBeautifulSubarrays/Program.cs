using System;
using System.Collections.Generic;

namespace CountTheNumberOfBeautifulSubarrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long BeautifulSubarrays(int[] nums)
        {
            long res = 0;
            var dict = new Dictionary<int, long> { { 0, 1 } };
            var xOr = 0;
            foreach (var num in nums)
            {
                xOr ^= num;
                if (!dict.ContainsKey(xOr))
                    dict[xOr] = 0;
                res += dict[xOr];
                dict[xOr]++;
            }
            return res;
        }
    }
}
