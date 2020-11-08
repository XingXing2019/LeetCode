using System;

namespace GetMaximumInGeneratedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int GetMaximumGenerated(int n)
        {
            if (n < 2) return n;
            var nums = new int[n + 1];
            nums[1] = 1;
            var max = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                nums[i] = i % 2 == 0 ? nums[i / 2] : nums[i / 2] + nums[i / 2 + 1];
                max = Math.Max(max, nums[i]);
            }
            return max;
        }
    }
}
