using System;

namespace MaximumStrengthOfAGroup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MaxStrength(int[] nums)
        {
            if (nums.Length == 1)
                return (long)nums[0];
            long res = 1;
            int countNeg = 0, maxNeg = int.MinValue, times = 0;
            Array.Sort(nums);
            foreach (var num in nums)
            {
                if (num == 0) continue;
                if (num < 0)
                {
                    countNeg++;
                    maxNeg = Math.Max(maxNeg, num);
                }
                res *= num;
                times++;
            }
            if (times == 1 && countNeg == 1 || times == 0)
                return 0;
            return countNeg % 2 == 0 ? res : res / maxNeg;
        }
    }
}
