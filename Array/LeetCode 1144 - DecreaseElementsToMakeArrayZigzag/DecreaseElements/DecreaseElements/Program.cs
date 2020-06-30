//分别计算减小奇数位和偶数位所需减小数字的总和。返回较小的一个。
using System;
using System.Collections.Generic;

namespace DecreaseElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 9, 6, 1, 6, 2 };
            Console.WriteLine(MovesToMakeZigzag(nums));
        }
        static int MovesToMakeZigzag(int[] nums)
        {
            if (nums.Length <= 2) return 0;
            int decreaceOdd = 0, decreaceEven = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int decrease1 = 0, decrease2 = 0;
                if (i != 0 && nums[i] >= nums[i - 1])
                    decrease1 = nums[i] - nums[i - 1] + 1;
                if (i != nums.Length - 1 && nums[i] >= nums[i + 1])
                    decrease2 = nums[i] - nums[i + 1] + 1;
                if (i % 2 != 0)
                    decreaceOdd += Math.Max(decrease1, decrease2);
                else
                    decreaceEven += Math.Max(decrease1, decrease2);
            }
            return Math.Min(decreaceOdd, decreaceEven);
        }
    }
}
