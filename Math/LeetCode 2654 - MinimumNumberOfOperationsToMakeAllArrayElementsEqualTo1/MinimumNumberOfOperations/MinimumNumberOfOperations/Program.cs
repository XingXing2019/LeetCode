using System;
using System.Linq;

namespace MinimumNumberOfOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 6, 10, 15 };
            Console.WriteLine(MinOperations(nums));
        }

        public static int MinOperations(int[] nums)
        {
            var ones = nums.Count(x => x == 1);
            if (ones != 0) return nums.Length - ones;
            var min = int.MaxValue;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    nums[i] = GCD(nums[i], nums[j]);
                    if (nums[i] != 1) continue;
                    min = Math.Min(min, j - i);
                    break;
                }
            }
            return min == int.MaxValue ? -1 : nums.Length + min;
        }

        public static int GCD(int x, int y)
        {
            if (y == 0) return x;
            return GCD(y, x % y);
        }
    }
}
