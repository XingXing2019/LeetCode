using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NumberOfWays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startPos = 1, endPos = 2, k = 3;
            Console.WriteLine(NumberOfWays(startPos, endPos, k));
        }

        public static int NumberOfWays(int startPos, int endPos, int k)
        {
            long mod = 1_000_000_000 + 7;
            var dict1 = new Dictionary<int, long>{{startPos, 1}};
            while (k > 0)
            {
                k--;
                var dict2 = new Dictionary<int, long>();
                foreach (var pos in dict1.Keys)
                {
                    var count = dict1.GetValueOrDefault(pos, 0) % mod;
                    dict2[pos - 1] = dict2.GetValueOrDefault(pos - 1, 0) + count;
                    dict2[pos + 1] = dict2.GetValueOrDefault(pos + 1, 0) + count;
                }
                dict1 = dict2;
            }
            return (int)(dict1.GetValueOrDefault(endPos, 0) % mod);
        }
    }
}
