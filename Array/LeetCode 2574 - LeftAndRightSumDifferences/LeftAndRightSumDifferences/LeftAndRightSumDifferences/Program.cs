using System;

namespace LeftAndRightSumDifferences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] LeftRigthDifference(int[] nums)
        {
            var leftSum = new int[nums.Length];
            var rightSum = new int[nums.Length];
            var res = new int[nums.Length];
            int left = 0, right = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                leftSum[i] = left;
                left += nums[i];
                rightSum[^(i + 1)] = right;
                right += nums[^(i + 1)];
            }
            for (int i = 0; i < res.Length; i++)
                res[i] = Math.Abs(leftSum[i] - rightSum[i]);
            return res;
        }
    }
}
