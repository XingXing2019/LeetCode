//与LeetCode-26解法类似。创建指针指向数组第一个元素。
//遍历数组，如果当前遍历到的元素不为零，且pos指向的元素为0，则调换两个元素，同时pos向前移动一位。
//如果这时pos指向的元素不为0，则pos继续向前移动一位。否则pos原地不动。
using System;

namespace MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public void MoveZeroes_Swap(int[] nums)
        {
            int li = 0;
            for (int hi = 1; hi < nums.Length; hi++)
            {
                if (nums[hi] != 0 && nums[li] == 0)
                {
                    int temp = nums[hi];
                    nums[hi] = nums[li];
                    nums[li++] = temp;
                }
                if(nums[li] != 0)
                    li++;
            }
        }
        public void MoveZeroes_NonSwap(int[] nums)
        {
            int li = 0;
            for (int hi = 0; hi < nums.Length; hi++)
            {
                if (nums[hi] != 0)
                    nums[li++] = nums[hi];
            }
            for (int i = li; i < nums.Length; i++)
                nums[i] = 0;
        }
    }
}
