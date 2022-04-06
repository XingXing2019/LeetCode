using System;

namespace WaysToMakeAFairArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int WaysToMakeFair(int[] nums)
        {
            int[] before = new int[nums.Length], after = new int[nums.Length];
            int beforeOdd = 0, beforeEven = 0, afterOdd = 0, afterEven = 0;
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                before[i] = beforeEven - beforeOdd;
                beforeEven += i % 2 == 0 ? nums[i] : 0;
                beforeOdd += i % 2 == 0 ? 0 : nums[i];
            }
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                after[i] = afterEven - afterOdd;
                afterEven += i % 2 == 0 ? nums[i] : 0;
                afterOdd += i % 2 == 0 ? 0 : nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (before[i] == after[i])
                    res++;
            }
            return res;
        }
    }
}
