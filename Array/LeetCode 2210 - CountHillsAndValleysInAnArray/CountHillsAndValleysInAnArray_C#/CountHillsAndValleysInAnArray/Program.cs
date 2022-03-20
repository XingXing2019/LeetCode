using System;
using System.Collections.Generic;
using System.Linq;

namespace CountHillsAndValleysInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountHillValley(int[] nums)
        {
            var unique = nums.Where((t, i) => i == 0 || t != nums[i - 1]).ToList();
            if (unique.Count < 3) return 0;
            var isUp = unique[1] > unique[0];
            var res = 0;
            for (int i = 1; i < unique.Count; i++)
            {
                if (unique[i] > unique[i - 1])
                {
                    if (!isUp)
                        res++;
                    isUp = true;
                }
                else
                {
                    if (isUp)
                        res++;
                    isUp = false;
                }
            }
            return res;
        }
    }
}
