//找到最大值，再根据要求做比较操作。
using System;
using System.Linq;

namespace LargestNumberAtLeastTwiceOfOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 6, 1, 0 };
            Console.WriteLine(DominantIndex(nums));
        }
        static int DominantIndex(int[] nums)
        {
            int max = nums.Max(n => n);
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == max)
                    index = i;
                else if (max < 2 * nums[i])
                    return -1;
            }
            return index;
        }
    }
}
