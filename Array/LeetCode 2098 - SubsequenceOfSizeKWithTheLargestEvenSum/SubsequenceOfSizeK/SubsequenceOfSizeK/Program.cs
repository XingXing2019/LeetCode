
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SubsequenceOfSizeK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 5 };
            int k = 1;
            Console.WriteLine(LargestEvenSum(nums, k));
        }

        public static long LargestEvenSum(int[] nums, int k)
        {
            List<long> odd = new List<long>(), even = new List<long>();
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                    even.Add(num);
                else
                    odd.Add(num);
            }
            odd = odd.OrderByDescending(x => x).ToList();
            even = even.OrderByDescending(x => x).ToList();
            for (int i = 1; i < odd.Count; i++)
                odd[i] += odd[i - 1];
            for (int i = 1; i < even.Count; i++)
                even[i] += even[i - 1];
            long res = long.MinValue;
            for (int i = 0; i <= k; i++)
            {
                if (i == 0 && k - 1 < even.Count && even[k - 1] % 2 == 0)
                    res = Math.Max(res, even[k - 1]);
                else if (i == k && k - 1 < odd.Count && odd[k - 1] % 2 == 0)
                    res = Math.Max(res, odd[k - 1]);
                else if (i - 1 >= 0 && i - 1 < odd.Count && k - i - 1 >= 0 && k - i - 1 < even.Count && (odd[i - 1] + even[k - i - 1]) % 2 == 0)
                    res = Math.Max(res, odd[i - 1] + even[k - i - 1]);
            }
            return res == long.MinValue ? -1 : res;
        }
    }
}
