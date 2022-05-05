//暴力算法会超时，用一个数组记录以每个数字结尾到数组头乘积的方法会出现溢出。
//使用li和hi维护一个滑动窗口。创建li和hi指针，初始值指向数组头。创建product记录乘积，初始值设为1。创建res记录结果。
//在hi不越界的条件下使hi向数组尾移动。将其指向数字乘入product。
//然后在li不超过hi的条件下滑动li，每次滑动前，令product除以li指向数字。试图找到product小于k的位置。则hi和li指向的数字数量为子数组的数量，将其计入res。
using System;

namespace SubarrayProductLessThanK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 3, 2, 4, 5, 6, 4, 32, 2, 34, 2, 4, 3, 2 };
            int K = 120;
            Console.WriteLine(NumSubarrayProductLessThanK2(nums, K));
        }
        static int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int res = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int product = nums[i];
                if (product < k)
                    res++;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    product *= nums[j];
                    if (product < k)
                        res++;
                    else
                        break;
                }
            }
            if (nums[nums.Length - 1] < k)
                res++;
            return res;
        }
        static int NumSubarrayProductLessThanK2(int[] nums, int k)
        {
            int li = 0, hi = 0, product = 1, res = 0;
            while (hi < nums.Length)
            {
                product *= nums[hi];
                while (li <= hi && product >= k)
                {
                    product /= nums[li];
                    li++;
                }
                res += hi - li + 1;
                hi++;
            }
            return res;
        }
    }
}
