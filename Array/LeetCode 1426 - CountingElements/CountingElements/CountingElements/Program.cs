using System;
using System.Collections.Generic;

namespace CountingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 2, 3, 5, 0 };
            Console.WriteLine(CountElements(arr));
        }
        static int CountElements(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                    dict[num]++;
            }
            int res = 0;
            foreach (var kv in dict)
            {
                if (dict.ContainsKey(kv.Key + 1))
                    res += kv.Value;
            }
            return res;
        }
    }
}
