using System;

namespace SumOfSubarrayRanges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public long SubArrayRanges(int[] nums)
        {
            long res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int min = nums[i], max = nums[i];
                for (int j = i; j < nums.Length; j++)
                {
                    min = Math.Min(min, nums[j]);
                    max = Math.Max(max, nums[j]);
                    res += max - min;
                }
            }
            return res;
        }
    }
}
