using System;

namespace RemovingMinimumAndMaximumFromArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumDeletions(int[] nums)
        {
            int min = int.MaxValue, max = int.MinValue, indexMin = 0, indexMax = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    indexMax = i;
                }
                if (nums[i] < min)
                {
                    min = nums[i];
                    indexMin = i;
                }
            }
            var op1 = Math.Max(indexMin, indexMax) + 1;
            var op2 = Math.Max(nums.Length - indexMin, nums.Length - indexMax);
            var op3 = indexMin + 1 + nums.Length - indexMax;
            var op4 = nums.Length - indexMin + indexMax + 1;
            return Math.Min(op1, Math.Min(op2, Math.Min(op3, op4)));
        }
    }
}
