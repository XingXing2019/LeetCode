//创建min记录结果，初始值设为int的最大值。创建li和hi指针维护一个窗口，初始值指向数组第一个数字。创建sum记录窗口中数字之和，初始值设为数组第一个数字。
//字啊两个指针不越界的条件下遍历数组，如果sum大于s，先更新min为当前值与窗口宽度中较小的值。然后使sum减去当前li指向的数字，并使li右移，试图包括更少数字。
//如果sum大于s，则先使hi向右移，试图包括更多的数字。在hi不越界的条件下使sum加上当前hi指向的数字。
//遍历结束后如果min仍未被替换过，则证明没有符合条件的数组，那么是min等于0.
using System;

namespace MinimumSizeSubarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, 1, 2, 4, 3 };
            int s = 7;
            Console.WriteLine(MinSubArrayLen(s, nums));
        }
        static int MinSubArrayLen(int s, int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int min = int.MaxValue;
            int li = 0;
            int hi = 0;
            int sum = nums[0];
            while (hi < nums.Length && li < nums.Length)
            {
                if (sum >= s)
                {
                    min = Math.Min(min, hi - li + 1);
                    sum -= nums[li++];
                }
                else
                {
                    if (++hi > nums.Length - 1)
                        break;
                    sum += nums[hi];
                }
            }
            if (min == int.MaxValue)
                min = 0;
            return min;
        }
    }
}
