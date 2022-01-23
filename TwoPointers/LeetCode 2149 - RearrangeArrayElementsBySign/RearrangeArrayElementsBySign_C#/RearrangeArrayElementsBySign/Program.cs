using System;
using System.Collections.Generic;

namespace RearrangeArrayElementsBySign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] RearrangeArray(int[] nums)
        {
            var negative = new List<int>();
            var positive = new List<int>();
            foreach (var num in nums)
            {
                if (num < 0)
                    negative.Add(num);
                else
                    positive.Add(num);
            }
            int p1 = 0, p2 = 0, p = 0;
            var res = new int[nums.Length];
            while (p < res.Length)
            {
                res[p++] = positive[p1++];
                res[p++] = negative[p2++];
            }
            return res;
        }
    }
}
