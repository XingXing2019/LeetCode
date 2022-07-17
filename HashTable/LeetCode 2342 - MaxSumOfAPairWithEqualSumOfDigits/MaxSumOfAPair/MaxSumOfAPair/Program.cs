using System;
using System.Collections.Generic;

namespace MaxSumOfAPair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaximumSum(int[] nums)
        {
            var dict = new Dictionary<int, List<int>>();
            foreach (var num in nums)
            {
                var sum = GetSum(num);
                if (!dict.ContainsKey(sum))
                    dict.Add(sum, new List<int>());
                dict[sum].Add(num);
            }
            var res = -1;
            foreach (var value in dict.Values)
            {
                if (value.Count < 2) continue;
                value.Sort();
                res = Math.Max(res, value[^1] + value[^2]);
            }
            return res;
        }

        private int GetSum(int num)
        {
            var res = 0;
            while (num != 0)
            {
                res += num % 10;
                num /= 10;
            }
            return res;
        }
    }
}
