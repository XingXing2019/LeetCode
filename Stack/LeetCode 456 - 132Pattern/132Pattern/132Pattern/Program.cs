using System;
using System.Collections.Generic;

namespace _132Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 42, 43, 6, 12, 3, 4, 6, 11, 20 };
            Console.WriteLine(Find132pattern(nums));
        }
        public static bool Find132pattern(int[] nums)
        {
            int[] leftMin = new int[nums.Length], rightMax = new int[nums.Length];
            int min = int.MaxValue;
            for (int i = 0; i < leftMin.Length; i++)
            {
                leftMin[i] = min;
                min = Math.Min(min, nums[i]);
            }
            var sorted = new List<int>();
            for (int i = rightMax.Length - 1; i >= 0; i--)
            {
                int index = sorted.BinarySearch(nums[i]);
                if (index < 0) index = ~index;
                sorted.Insert(index, nums[i]);
                rightMax[i] = index == 0 ? int.MinValue : sorted[index - 1];
            }
            for (int i = 0; i < leftMin.Length; i++)
            {
                if (leftMin[i] < nums[i] && nums[i] > rightMax[i] && rightMax[i] > leftMin[i])
                    return true;
            }
            return false;
        }
    }
}
