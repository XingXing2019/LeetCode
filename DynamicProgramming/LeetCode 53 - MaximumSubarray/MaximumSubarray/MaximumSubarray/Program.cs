//应用动态规划思想。对于数组中的每个数，在该点只存在两种情况。第一种情况为加上之前的数组，那么在该点能达到的最大加和为该点数字加加上一点能达到的最大加和。
//第二种情况为不加上之前的数组。那么在该点能达到的最大加和即为该点的数字。
//创建一个数组dpMaxSum记录在每个点能达到的最大加和。
//将在第一个点能到达的最大值设为该点数字。创建一个数字maxSum用于记录加和的最大值，初始值设为dpMaxSum[0]。
//遍历数组，当前点能达到加和的最大值为：其前一点能达到的最大值加该点数字，和该点数字中较大的一个。如果此时该点能达到的最大值大于maxSum，则用其替换maxSum。
//最后返回maxSum。
using System;

namespace MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -1, -2 };
            Console.WriteLine(MaxSubArray(nums));
        }
        static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
                return int.MinValue;
            if (nums.Length == 1)
                return nums[0];
            int[] dpMaxSum = new int[nums.Length];
            dpMaxSum[0] = nums[0];
            int maxSum = dpMaxSum[0];
            for (int i = 1; i < dpMaxSum.Length; i++)
            {
                dpMaxSum[i] = Math.Max((dpMaxSum[i - 1] + nums[i]), nums[i]);
                if (dpMaxSum[i] > maxSum)
                    maxSum = dpMaxSum[i];
            }
            return maxSum;                
        }
    }
}
