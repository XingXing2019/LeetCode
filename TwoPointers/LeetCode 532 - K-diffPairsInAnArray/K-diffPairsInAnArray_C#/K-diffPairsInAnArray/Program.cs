//先将数组排序，创建li和hi指针，分别指向第一和第二个元素。创建res记录结果。
//在hi不越界的条件下遍历数组。如果li和hi指向数字之差为k，则使res加一，并使hi在不越界的条件下向右移动，直到找到下一个不同的数字(这样可以保证不会有重复的数字对出现)。
//如果li和hi指向数字之差小于k，则使hi向右移动一位。
//如果li和hi指向数字之差大于k，则在li和hi不相邻的情况下使li向右移动一位(这样保证li和hi不重合)。否则使hi向右移动一位。
//最后返回res。
using System;

namespace K_diffPairsInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 1, 1 };
            int k = 0;
            Console.WriteLine(FindPairs(nums, k));
        }
        static int FindPairs(int[] nums, int k)
        {
            Array.Sort(nums);
            int li = 0;
            int hi = li + 1;
            int res = 0;
            while (hi < nums.Length)
            {
                if (nums[hi] - nums[li] == k)
                {
                    res++;
                    int tem = nums[hi];
                    while (hi < nums.Length && nums[hi] == tem)
                        hi++;
                }
                else if (nums[hi] - nums[li] < k)
                    hi++;
                else
                {
                    if (hi - li > 1)
                        li++;
                    else
                        hi++;
                }
            }
            return res;
        }

}
}
