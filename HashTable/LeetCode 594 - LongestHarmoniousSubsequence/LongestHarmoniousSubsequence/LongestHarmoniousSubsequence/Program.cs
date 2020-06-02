//创建字典记录每个数字出现的次数。遍历字典，如果当前数字加一也在字典中，则有他们组成的子数组长度为两个数在字典中值的和。
//无需考虑两个数字的位置，肯定有一个会在另一个之前出现。
using System;
using System.Collections.Generic;

namespace LongestHarmoniousSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 2, 2, 5, 2, 3, 7 };
            Console.WriteLine(FindLHS(nums));
        }
        static int FindLHS(int[] nums)
        {
            var numFrequency = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!numFrequency.ContainsKey(num))
                    numFrequency[num] = 1;
                else
                    numFrequency[num]++;
            }
            int res = 0;
            foreach (var kv in numFrequency)
            {
                int tem = 0;
                if (numFrequency.ContainsKey(kv.Key + 1))
                    tem = kv.Value + numFrequency[kv.Key + 1];
                res = Math.Max(res, tem);
            }
            return res;
        }
    }
}
