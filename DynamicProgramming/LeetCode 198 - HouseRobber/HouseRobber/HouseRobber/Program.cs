//应用动态规划思想。子问题为选择或者不选择当前房间。如果选择，那么在此房间最大收益为在向前间隔一个房间的最大收益加上此房间的收益。
//如果不选，那么在此房间的最大收益为其前一个房间的最大收益。只需比较选择两种情况中的最大值设为此房间的最大收益。通过动态编程可以规划出所有房间的最大收益。
//创建数组dpMaxProfit记录每个房间的最大收益。其长度和nums相等。
//在第一个房间的最大收益为第一个房间的财宝。在第二个房间的最大收益为第一个房间和第二个房间财宝的较大值。
//从第三个房间开始遍历数组，遍历到房间的最大收益为：向前隔一个房间的最大收益加上当前房间财宝，和之前一个房间的最大收益中较大的值、
//最后返回在最后一个房间的最大收益即可。
using System;

namespace HouseRobber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 2, 6, 3, 1, 7 };
            Console.WriteLine(Rob(nums));
        }
        static int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            int[] dpMaxProfit = new int[nums.Length];
            dpMaxProfit[0] = nums[0];
            dpMaxProfit[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < dpMaxProfit.Length; i++)
            {
                dpMaxProfit[i] = Math.Max((dpMaxProfit[i - 2] + nums[i]), dpMaxProfit[i - 1]);
            }
            return dpMaxProfit[dpMaxProfit.Length - 1];
        }
        static int Rob_O1Space(int[] nums)
        {
            if (nums.Length == 0) return 0;
            for (int i = 1; i < nums.Length; i++)
            {
                int temp = i == 1 ? 0 : nums[i - 2];
                nums[i] = Math.Max(temp + nums[i], nums[i - 1]);
            }
            return nums[nums.Length - 1];
        }
    }
}
