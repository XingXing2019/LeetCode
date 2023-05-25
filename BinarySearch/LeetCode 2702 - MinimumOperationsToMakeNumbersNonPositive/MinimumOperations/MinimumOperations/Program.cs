using System;
using System.Linq;

namespace MinimumOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 1 };
            int x = 2, y = 1;
            Console.WriteLine(MinOperations(nums, x, y));
        }

        public static int MinOperations(int[] nums, int x, int y)
        {
            Array.Sort(nums, (a, b) => b - a);
            int li = 0, hi = nums.Max() / y + 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (CanAchieve(nums, mid, x, y))
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return li;
        }

        public static bool CanAchieve(int[] nums, int times, int x, int y)
        {
            var max = times;
            foreach (var num in nums)
            {
                var count = (int)Math.Ceiling((double)(num - times * y) / (x - y));
                max -= Math.Max(0, count);
                if (max < 0) return false;
            }
            return true;
        }
    }
}
