using System;
using System.Collections.Generic;

namespace NumberOfGoodPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumIdenticalPairs_Array(int[] nums)
        {
            var frequencies = new int[101];
            var res = 0;
            foreach (var num in nums)
            {
                res += frequencies[num];
                frequencies[num]++;
            }
            return res;
        }

        static int NumIdenticalPairs_Dictionary(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            var res = 0;
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                {
                    res += dict[num];
                    dict[num]++;
                }
            }
            return res;
        }
    }
}
