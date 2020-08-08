//对原始数组排序，找到新数组与原始数组第一个和最后一个数字不同的位置。这段数组的长度即为结果。
//需要注意验证原始数组已经是排好序的特殊情况。
using System;

namespace ShortestUnsortedContinuousSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 6, 4, 8, 10, 9, 15 };
            Console.WriteLine(FindUnsortedSubarray_N(nums));
        }
        static int FindUnsortedSubarray_LogN(int[] nums)
        {
            int[] tem = new int[nums.Length];
            Array.Copy(nums, tem, nums.Length);
            Array.Sort(nums);
            int start = 0, end = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != tem[i])
                {
                    start = i;
                    break;
                }
            }
            for (int i = nums.Length-1; i >= 0; i--)
            {
                if (nums[i] != tem[i])
                {
                    end = i;
                    break;
                }
            }
            return end == start ? 0 : end - start + 1;
        }

        static int FindUnsortedSubarray_N(int[] nums)
        {
            int start = 0, end = 0;
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                if (nums[i] < max)
                    end = i;
                min = Math.Min(min, nums[^(i + 1)]);
                if (nums[^(i + 1)] > min)
                    start = nums.Length - i - 1;
            }
            return start == end ? 0 : end - start + 1;
        }
    }
}
