using System;

namespace MinimumScoreByChangingTwoElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimizeSum(int[] nums)
        {
            Array.Sort(nums);
            return Math.Min(nums[^1] - nums[2], Math.Min(nums[^3] - nums[0], nums[^2] - nums[1]));
        }
    }
}
