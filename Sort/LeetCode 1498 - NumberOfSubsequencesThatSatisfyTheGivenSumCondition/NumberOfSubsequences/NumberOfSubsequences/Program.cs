//是用双指针确定最大的滑窗，在滑窗左右边界之和小于等于target的条件下滑动左边界。没记记录新增的组合的数量。
//n个元素组合的数量等于2^(n-1)。
using System;

namespace NumberOfSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            //             0  1  2  3  4  5
            int[] nums = { 2, 3, 3, 4, 6, 7 };
            int target = 12;
            Console.WriteLine(NumSubseq(nums, target));
        }
        static int NumSubseq(int[] nums, int target)
        {
            Array.Sort(nums);
            var mod = 1_000_000_000 + 7;
            int left = 0, right = nums.Length - 1;
            long res = 0;
            var powers = new long[nums.Length];
            powers[0] = 1;
            for (int i = 1; i < powers.Length; i++)
                powers[i] = (powers[i - 1] * 2) % mod;
            while (left <= right)
            {
                if (nums[left] + nums[right] > target)
                    right--;
                else
                {
                    res = (res + powers[right - left]) % mod;
                    left++;
                }
            }
            return (int) res % mod;
        }
    }
}
