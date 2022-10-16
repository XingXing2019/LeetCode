using System;
using System.Collections.Generic;

namespace LargestPositiveInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindMaxK(int[] nums)
        {
            HashSet<int> pos = new HashSet<int>(), neg = new HashSet<int>();
            foreach (var num in nums)
            {
                if (num > 0)
                    pos.Add(num);
                else
                    neg.Add(-num);
            }
            var res = -1;
            foreach (var num in pos)
            {
                if (!neg.Contains(num)) continue;
                res = Math.Max(res, num);
            }
            return res;
        }
    }
}
