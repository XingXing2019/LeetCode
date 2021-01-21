//直接在原数组上操作。一路加过去。
using System;

namespace RunningSumOf1dArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            return nums;
        }
    }
}
