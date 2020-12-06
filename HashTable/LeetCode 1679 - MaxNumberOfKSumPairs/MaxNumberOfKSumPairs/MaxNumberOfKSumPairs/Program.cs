using System;
using System.Collections.Generic;

namespace MaxNumberOfKSumPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxOperations(int[] nums, int k)
        {
            var res = 0;
            var record = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!record.ContainsKey(k - num) || record[k - num] == 0)
                {
                    if (!record.ContainsKey(num))
                        record[num] = 0;
                    record[num]++;
                }
                else
                {
                    record[k - num]--;
                    res++;
                }
            }
            return res;
        }
    }
}
