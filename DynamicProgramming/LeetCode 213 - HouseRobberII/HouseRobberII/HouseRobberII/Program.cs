//需要分第一间房进和不进两种情况分别讨论。
//创建firstIn和firstNotIng两个数组，长度与nums相同。firstIn第一和第二个数字设为nums[0]。firstNotIn第二个数字设为nums[1]。
//从第三个数字遍历到倒数第二个数字，firstIn[i]设为firstIn[i - 2] + nums[i]和firstIn[i - 1]中较大的值。firstNotIn[i]设为firstNotIn[i - 2] + nums[i]和firstNotIn[i - 1]中较大的值。
//将firstIn最后一个数字设为其倒数第二个数字，将firstNotIn最后一个数字设为firstNotIn[len - 3] + nums[len - 1]与firstNotIn[len - 2]中较大的值。
//最后返回两个数组最后一个值中较大的值。
using System;

namespace HouseRobberII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, 2, 4, 2 };
            Console.WriteLine(Rob(nums));
        }
        static int Rob(int[] nums)
        {
            int len = nums.Length;
            if (len == 0)
                return 0;
            if (len == 1)
                return nums[0];
            if (len == 2)
                return Math.Max(nums[0], nums[1]);
            int[] firstNotIn = new int[len];
            int[] firstIn = new int[len];
            firstIn[0] = firstIn[1] = nums[0];
            firstNotIn[1] = nums[1];
            for (int i = 2; i < len - 1; i++)
            {
                firstIn[i] = Math.Max(firstIn[i - 2] + nums[i], firstIn[i - 1]);
                firstNotIn[i] = Math.Max(firstNotIn[i - 2] + nums[i], firstNotIn[i - 1]);
            }
            firstIn[len - 1] = firstIn[len - 2];
            firstNotIn[len - 1] = Math.Max(firstNotIn[len - 3] + nums[len - 1], firstNotIn[len - 2]);
            return Math.Max(firstNotIn[len - 1], firstIn[len - 1]);
        }
    }
}
