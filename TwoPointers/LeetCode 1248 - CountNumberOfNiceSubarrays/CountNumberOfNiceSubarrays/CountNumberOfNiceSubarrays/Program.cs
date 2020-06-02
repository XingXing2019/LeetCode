//创建字典record，计算以每个数字为结尾，向前数奇数的个数，将这个个数的出现的频率记入record。相当于记录了在几个位置上，之前有该个数的奇数
//遍历record，如果发现当前奇数个数减去k也在record中，则证明这两个出现频率之间的所有子串都满足条件。用当前计数个数出现的频率乘以kv.key - k上的频率，并计入res。
using System;
using System.Collections.Generic;

namespace CountNumberOfNiceSubarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 };
            int k = 2;
            Console.WriteLine(NumberOfSubarrays(nums, k));
        }
        static int NumberOfSubarrays(int[] nums, int k)
        {
            var record = new Dictionary<int, int>();
            record[0] = 1;
            int numOfOdd = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0)
                    numOfOdd++;
                if (record.ContainsKey(numOfOdd))
                    record[numOfOdd]++;
                else
                    record[numOfOdd] = 1;
            }
            int res = 0;
            foreach (var kv in record)
            {
                if (record.ContainsKey(kv.Key - k))
                    res += record[kv.Key - k] * kv.Value;
            }
            return res;
        }
    }
}
