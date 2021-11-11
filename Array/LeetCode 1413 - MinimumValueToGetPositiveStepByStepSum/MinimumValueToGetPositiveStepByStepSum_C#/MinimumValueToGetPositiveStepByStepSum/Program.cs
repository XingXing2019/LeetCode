using System;

namespace MinimumValueToGetPositiveStepByStepSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-3, 2, -3, 4, 2};
            Console.WriteLine(MinStartValue(nums));
        }
        static int MinStartValue(int[] nums)
        {
            int sum = 0;
            int min = int.MaxValue;
            foreach (var num in nums)
            {
                sum += num;
                min = Math.Min(min, sum);
            }
            return Math.Max(1, 1 - min);
        }
    }
}
