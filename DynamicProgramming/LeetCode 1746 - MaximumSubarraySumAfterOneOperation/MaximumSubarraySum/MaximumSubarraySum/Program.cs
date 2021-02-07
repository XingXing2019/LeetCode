using System;

namespace MaximumSubarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxSumAfterOperation(int[] nums)
        {
            var noSquare = new int[nums.Length];
            var withSquare = new int[nums.Length];
            withSquare[0] = nums[0] * nums[0];
            noSquare[0] = Math.Max(0, nums[0]);
            int res = Math.Max(withSquare[0], noSquare[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                int square = nums[i] * nums[i];
                noSquare[i] = Math.Max(nums[i], nums[i] + noSquare[i - 1]);
                withSquare[i] = Math.Max(square, Math.Max(noSquare[i - 1] + square, withSquare[i - 1] + nums[i]));
                res = Math.Max(res, Math.Max(withSquare[i], noSquare[i]));
            }
            return res;
        }
    }
}
