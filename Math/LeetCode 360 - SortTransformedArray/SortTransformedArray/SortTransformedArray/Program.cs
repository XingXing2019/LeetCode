using System;

namespace SortTransformedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -99, -94, -90, 75, 79, 97, 98 };
            int a = -2, b = 3, c = -2;
            Console.WriteLine(SortTransformedArray(nums, a, b, c));
        }
        static int[] SortTransformedArray(int[] nums, int a, int b, int c)
        {
            var res = new int[nums.Length];
            int index = 0;
            if (a == 0)
            {
                foreach (var num in nums)
                    res[index++] = a * num * num + b * num + c;
                if(b < 0) Array.Reverse(res);
                return res;
            }
            var midLine = -(double) b / (2 * a);
            int li = 0, hi = nums.Length - 1;
            while (li <= hi)
            {
                if (Math.Abs(nums[li] - midLine) < Math.Abs(nums[hi] - midLine))
                {
                    res[index++] = a * nums[hi] * nums[hi] + b * nums[hi] + c;
                    hi--;
                }
                else
                {
                    res[index++] = a * nums[li] * nums[li] + b * nums[li] + c;
                    li++;
                }
            }
            if(a > 0)
                Array.Reverse(res);
            return res;
        }
    }
}
