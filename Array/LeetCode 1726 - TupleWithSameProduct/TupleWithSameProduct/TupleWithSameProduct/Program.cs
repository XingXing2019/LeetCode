using System;
using System.Collections.Generic;

namespace TupleWithSameProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int TupleSameProduct(int[] nums)
        {
            var res = 0;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (!dict.ContainsKey(nums[i] * nums[j]))
                        dict[nums[i] * nums[j]] = 0;
                    else
                        res += 8 * dict[nums[i] * nums[j]];
                    dict[nums[i] * nums[j]]++;
                }
            }
            return res;
        }
    }
}
