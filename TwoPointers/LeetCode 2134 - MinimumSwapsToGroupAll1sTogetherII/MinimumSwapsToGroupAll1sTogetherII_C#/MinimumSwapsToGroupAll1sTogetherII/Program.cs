using System;
using System.Linq;

namespace MinimumSwapsToGroupAll1sTogetherII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 1, 1, 0, 0, 1, 1, 0 };
            Console.WriteLine(MinSwaps(nums));
        }

        public static int MinSwaps(int[] nums)
        {
            return Math.Min(SlideWindow(nums, 0), SlideWindow(nums, 1));
        }

        public static int SlideWindow(int[] nums, int numToCheck)
        {
            int num1 = nums.Count(x => x == numToCheck);
            int num2 = nums[..num1].Count(x => x == (numToCheck ^ 1));
            int li = 0, hi = num1 - 1, min = int.MaxValue;
            while (hi < nums.Length - 1)
            {
                min = Math.Min(min, num2);
                if (nums[li++] == (numToCheck ^ 1))
                    num2--;
                if (nums[++hi] == (numToCheck ^ 1))
                    num2++;
            }
            return Math.Min(min, num2);
        }
    }
}
