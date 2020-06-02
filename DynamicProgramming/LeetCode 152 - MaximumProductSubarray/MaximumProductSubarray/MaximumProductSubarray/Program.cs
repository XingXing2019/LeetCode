//由于可能有负数存在，则存在负负为正的可能。因此需要同时记录以某一数字结尾的子数组能达到的最大值和最小值。因为最小值如果为负，其与下一个数字(负数)的乘积可能获得最大值
//无需创建数组，只需创建max和min记录当前的最大值和最小值。将他们的初始值设为nums的第一个数字。同时创建res记录结果，将其初始值设为max。
//从第二个数字开始遍历，创建temMax和temMin临时记录当前max和min，因为在之后的操作中会改变max和min的值。
//每轮遍历将max更新为，当前数字，当前数字与temMax乘积，当前数字与temMin乘积，三者中的最大值。将min更新为，当前数字，当前数字与temMax乘积，当前数字与temMin乘积，三者中的最小值。
//如果更新后的max大于res，则更新res。遍历结束后返回res。
using System;

namespace MaximumProductSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, -2, 4 };
            Console.WriteLine(MaxProduct(nums));
        }
        static int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int max = nums[0], min = nums[0];
            int res = max;
            for (int i = 1; i < nums.Length; i++)
            {
                int temMax = max;
                int temMin = min;
                max = Math.Max(nums[i], Math.Max(nums[i] * temMax, nums[i] * temMin));
                min = Math.Min(nums[i], Math.Min(nums[i] * temMax, nums[i] * temMin));
                res = Math.Max(max, res);
            }
            return res;
        }

    }
}
