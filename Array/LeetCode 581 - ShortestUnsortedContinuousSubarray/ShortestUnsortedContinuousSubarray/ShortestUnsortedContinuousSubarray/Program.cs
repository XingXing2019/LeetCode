//对原始数组排序，找到新数组与原始数组第一个和最后一个数字不同的位置。这段数组的长度即为结果。
//需要注意验证原始数组已经是排好序的特殊情况。
using System;

namespace ShortestUnsortedContinuousSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };
            Console.WriteLine(FindUnsortedSubarray(nums));
        }
        static int FindUnsortedSubarray(int[] nums)
        {
            int[] tem = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                tem[i] = nums[i];
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
            if (end == start)
                return 0;
            return end - start + 1;
        }
    }
}
