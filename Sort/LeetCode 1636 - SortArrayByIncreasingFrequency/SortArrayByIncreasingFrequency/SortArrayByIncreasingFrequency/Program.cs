using System;
using System.Collections.Generic;
using System.Linq;

namespace SortArrayByIncreasingFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 1, 2, 2, 2, 3};
            Console.WriteLine(FrequencySort_Linq(nums));
        }
        static int[] FrequencySort_Linq(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 0;
                dict[num]++;
            }
            dict = dict.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            var res = new int[nums.Length];
            int index = 0;
            foreach (var kv in dict)
            {
                for (int i = 0; i < kv.Value; i++)
                    res[index++] = kv.Key;
            }
            return res;
        }
    }
}
