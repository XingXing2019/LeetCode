//维护一段长度为k的窗口，滑动窗口找到其中数字能达到的最大之和。
//可以通过创建一个数组记录以每个数字结尾的子数组之和，这样可以减少重复计算。窗口内数字之和为窗口右端到数组头之和减去窗口左端前一位到数组头之和。
using System;

namespace MaximumAverageSubarrayI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1 };
            int k = 1;
            Console.WriteLine(FindMaxAverage(nums, k));
        }
        static double FindMaxAverage(int[] nums, int k)
        {
            int[] sum = new int[nums.Length + 1];
            sum[1] = nums[0];
            for (int i = 2; i <= nums.Length; i++)
                sum[i] = sum[i - 1] + nums[i - 1];
            double res = int.MinValue;
            for (int i = k; i < sum.Length; i++)
            {
                double tem = sum[i] - sum[i - k];
                res = Math.Max(res, tem / k);
            }
            return res;
        }
    }
}
