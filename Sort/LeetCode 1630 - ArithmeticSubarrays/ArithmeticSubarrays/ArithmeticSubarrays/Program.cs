using System;
using System.Collections.Generic;

namespace ArithmeticSubarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            var res = new bool[l.Length];
            for (int i = 0; i < res.Length; i++)
                res[i] = true;
            for (int i = 0; i < l.Length; i++)
            {
                var set = nums[l[i]..(r[i] + 1)];
                Array.Sort(set);
                var diff = set[1] - set[0];
                for (int j = 1; j < set.Length; j++)
                {
                    if (set[j] - set[j - 1] != diff)
                    {
                        res[i] = false;
                        break;
                    }
                }
            }
            return res;
        }
    }
}
