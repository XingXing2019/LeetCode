//创建一个字典sumFrequency记录数组中每个数字与其之前所有数字之和，已经这个和出现的次数。需要将[0,1]人为记入sumFrequency代表在第一位之前的数字之和为0.
//遍历数组，用sum记录当前数字与其之前所有数字之和。如果sum-k存在于sumFrequency中，则证明在当前数字之前的一些位置存在到此位置为止的子数组，加和等于k。则将sum-k出现的次数记录入res。
//如果此时sum不在sumFrequency中，则将其加入，否则使其频率加一。
using System;
using System.Collections.Generic;

namespace SubarraySumEqualsK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-1, -1,  1};
            int k = 0;
            Console.WriteLine(SubarraySum(nums, k));
        }
        static int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> sumFrequency = new Dictionary<int, int>();
            sumFrequency[0] = 1;
            int sum = 0;
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sumFrequency.ContainsKey(sum - k))
                    res += sumFrequency[sum - k];
                if (!sumFrequency.ContainsKey(sum))
                    sumFrequency[sum] = 1;
                else
                    sumFrequency[sum]++;
            }
            return res;
        }
}
}
