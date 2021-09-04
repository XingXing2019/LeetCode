//创建GetSetLength方法传入数组和起头数字，用于找到每个不循环子数组的长度。创建record记录起头数字n。创建计数器统计子数组的长度，初始值设为1(起头数字n已经在子数组中)。
//在record不等于nums[n]的条件下循环。每次使count加一。并将n设为nums[n]。同时将遍历过得数字设为-1，以防止重复遍历相同的数字(需要创建tem辅助记录n，因为此时n已经变味nums[n])。最后返回count
//在主方法中创建maxLen记录最大长度。遍历nums，当nums[i]不等于-1时，计算以当前数字为开头的数字。并更新maxLen。
using System;

namespace ArrayNesting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 5, 4, 0, 3, 1, 6, 2 };
            Console.WriteLine(GetSetLength(A,5));
        }
        static int ArrayNesting(int[] nums)
        {
            int maxLen = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int len = 0;
                if(nums[i] != -1)
                    len = GetSetLength(nums, nums[i]);
                maxLen = Math.Max(maxLen, len);
            }
            return maxLen;
        }
        static int GetSetLength(int[] nums, int n)
        {
            int record = n;
            int count = 1;
            while (nums[n] != record)
            {
                int tem = n;
                count++;
                n = nums[n];
                nums[tem] = -1;
            }
            return count;
        }
    }
}
