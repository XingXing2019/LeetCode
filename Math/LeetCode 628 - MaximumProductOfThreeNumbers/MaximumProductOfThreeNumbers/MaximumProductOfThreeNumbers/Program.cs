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
            Console.WriteLine(MaximumProduct(nums));
        }
        static int MaximumProduct(int[] nums)
        {
            int firstlarge = int.MinValue, secondLarge = int.MinValue, thirdLarge = int.MinValue;
            int firstSmall = int.MaxValue, secondSmall = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > firstlarge)
                {
                    thirdLarge = secondLarge;
                    secondLarge = firstlarge;
                    firstlarge = nums[i];
                }
                else if (nums[i] > secondLarge)
                {
                    thirdLarge = secondLarge;
                    secondLarge = nums[i];
                }
                else if (nums[i] > thirdLarge)
                    thirdLarge = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < firstSmall)
                {
                    secondSmall = firstSmall;
                    firstSmall = nums[i];
                }
                else if (nums[i] < secondSmall)
                    secondSmall = nums[i];
            }
            return Math.Max(firstlarge * secondLarge * thirdLarge, firstlarge * firstSmall * secondSmall);
        }
    }
}
