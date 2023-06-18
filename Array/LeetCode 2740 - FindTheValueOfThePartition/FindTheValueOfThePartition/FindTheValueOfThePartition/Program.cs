using System;

namespace FindTheValueOfThePartition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 10, 100 };
            Console.WriteLine(FindValueOfPartition(nums));
        }

        public static int FindValueOfPartition(int[] nums)
        {
            Array.Sort(nums);
            var res = int.MaxValue;
            for (int i = 1; i < nums.Length; i++)
                res = Math.Min(res, nums[i] - nums[i - 1]);
            return res;
        }
    }
}
