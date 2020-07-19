//用一个字典记录前缀和以及index。遍历nums计算前缀和，如果前缀和在字典中没有记录，则将其和index计入字典。如果有记录则不用处理，因为之前出现过的index肯定能组成更长的子数组。
//如果前缀和减k在字典中有记录，则可以更新maxSize。
using System;
using System.Collections.Generic;

namespace MaximumSizeSubarraySumEqualsk
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, -1, 5, -2, 3};
            int k = 3;
            Console.WriteLine(MaxSubArrayLen(nums, k));
        }
        static int MaxSubArrayLen(int[] nums, int k)
        {
            var preSumIndex = new Dictionary<int, int>();
            preSumIndex[0] = -1;
            int preSum = 0, maxSize = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                preSum += nums[i];
                if (preSumIndex.ContainsKey(preSum - k))
                    maxSize = Math.Max(maxSize, i - preSumIndex[preSum - k]);
                if (!preSumIndex.ContainsKey(preSum))
                    preSumIndex[preSum] = i;
            }
            return maxSize;
        }
    }
}
