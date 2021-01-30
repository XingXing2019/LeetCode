//最大乘积一定为最大的三个数字相乘，或者最小的两个数字和最大的一个数字相乘。
//创建firstLarge，secondLarge，thirdLarge，firstSmall，secondSmall记录所需数组，这样不需要排序，可以通过一次遍历得到所有需要的数字。
using System;

namespace MaximumProductOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };
            Console.WriteLine(MaximumProduct_N(nums));
        }
        static int MaximumProduct_N(int[] nums)
        {
            int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
            int min1 = int.MaxValue, min2 = int.MaxValue;
            foreach (var num in nums)
            {
                if (num > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = num;
                }
                else if (num > max2)
                {
                    max3 = max2;
                    max2 = num;
                }
                else if (num > max3)
                    max3 = num;
                if (num < min1)
                {
                    min2 = min1;
                    min1 = num;
                }
                else if (num < min2)
                    min2 = num;
            }
            return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
        }

        static int MaximumProduct_NLogN(int[] nums)
        {
            Array.Sort(nums);
            return Math.Max(nums[0] * nums[1] * nums[nums.Length - 1],
                nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3]);
        }
    }
}
