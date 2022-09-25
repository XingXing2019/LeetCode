using System;
using System.Collections.Generic;

namespace FindAllGoodIndices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 87, 20, 17, 9, 3, 32, 47, 59, 84, 94 };
            var k = 4;
            Console.WriteLine(GoodIndices(nums, k));
        }

        public static IList<int> GoodIndices(int[] nums, int k)
        {
            var nonIncreasing = new int[nums.Length];
            var nonDecreasing = new int[nums.Length];
            int continueIncrease = 1, continueDecrease = 1;
            var res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0) continue;
                nonIncreasing[i] = continueIncrease;
                continueIncrease = nums[i] <= nums[i - 1] ? continueIncrease + 1 : 1;
                nonDecreasing[^(i + 1)] = continueDecrease;
                continueDecrease = nums[^(i + 1)] <= nums[^i] ? continueDecrease + 1 : 1;
            }
            for (int i = k; i < nums.Length - k; i++)
            {
                if (nonIncreasing[i] < k || nonDecreasing[i] < k) continue;
                res.Add(i);
            }
            return res;
        }
    }
}
