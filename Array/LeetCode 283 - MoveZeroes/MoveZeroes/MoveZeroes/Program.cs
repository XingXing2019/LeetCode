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
        public void MoveZeroes(int[] nums)
        {
            int pos = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != 0 && nums[pos] == 0)
                {
                    int tem = nums[i];
                    nums[i] = nums[pos];
                    nums[pos++] = tem;
                }
                if(nums[pos] != 0)
                    pos++;
            }
        }
    }
}
