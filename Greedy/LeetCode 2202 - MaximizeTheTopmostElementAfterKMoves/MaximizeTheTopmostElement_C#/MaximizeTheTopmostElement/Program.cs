using System;
using System.Linq;

namespace MaximizeTheTopmostElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 91, 98, 17, 79 };
            int k = 2;
            Console.WriteLine(MaximumTop(nums, k));
        }
        public static int MaximumTop(int[] nums, int k)
        {
            if (nums.Length == 1 && k % 2 == 1) return -1;
            if (k > nums.Length) return nums.Max();
            int index = 0, max = k == nums.Length ? 0 : nums[k];
            while (k > 1 && index < nums.Length)
            {
                max = Math.Max(max, nums[index++]);
                k--;
            }
            return max;
        }
    }
}
