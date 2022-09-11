//利用数组记录同样频率的数字，倒着遍历总能优先取到高频数字，空间换时间
using System;
using System.Collections.Generic;

namespace ReduceArraySizeToTheHalf
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1000, 1000, 3, 7 };
            Console.WriteLine(MinSetSize(arr));
        }
        static int MinSetSize(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                    dict[num]++;
            }
            List<int>[] frequencies = new List<int>[10001];
            foreach (var kv in dict)
            {
                if(frequencies[kv.Value] == null)
                    frequencies[kv.Value] = new List<int>{kv.Key};
                else
                    frequencies[kv.Value].Add(kv.Key);
            }
            int half = arr.Length / 2;
            int count = 0;
            int res = 0;
            for (int i = frequencies.Length-1; i >= 0 && count < half; i--)
            {
                if (frequencies[i] != null)
                {
                    for (int j = 0; j < frequencies[i].Count && count < half; j++)
                    {
                        count += i;
                        res += 1;
                    }
                }
            }
            return res;
        }
    }
}
