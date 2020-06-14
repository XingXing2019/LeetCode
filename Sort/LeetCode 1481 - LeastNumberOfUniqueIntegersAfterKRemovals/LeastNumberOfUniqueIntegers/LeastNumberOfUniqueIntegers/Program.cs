//统计一下每个频率有几个数字记录入frequencies数组。
//然后从低频率向高频率删除数字，这样可以更多地删除数字。最后统计一下frequencies里还剩下几个数字。
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeastNumberOfUniqueIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 1, 1, 3, 3, 3 };
            int k = 3;
            Console.WriteLine(FindLeastNumOfUniqueInts(arr, k));
        }
        static int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            var dict = new Dictionary<int, int>();
            int max = 0;
            foreach (var num in arr)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                    dict[num]++;
                max = Math.Max(max, dict[num]);
            }
            var frequencies = new int[max + 1];
            foreach (var kv in dict)
                frequencies[kv.Value]++;
            for (int i = 1; i < frequencies.Length && k >= i; i++)
            {
                int delete = Math.Min(frequencies[i], k / i);
                k = k - i * delete;
                frequencies[i] = frequencies[i] - delete;
            }
            return frequencies.Sum(x => x);
        }
    }
}
