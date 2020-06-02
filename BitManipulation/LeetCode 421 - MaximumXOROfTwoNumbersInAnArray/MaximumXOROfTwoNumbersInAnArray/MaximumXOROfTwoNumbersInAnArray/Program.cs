using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumXOROfTwoNumbersInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int FindMaximumXOR(int[] nums)
        {
            int max = 0, mask = 0;
            for (int i = 31; i >= 0; i--)
            {
                mask |= 1 << i;
                var set = new HashSet<int>();
                foreach (var num in nums)
                    set.Add(mask & num);
                int temp = max | (1 << i);
                foreach (var num in set)
                {
                    if (set.Contains(temp ^ num))
                        max = Math.Max(temp, max);
                }
            }
            return max;
        }
    }
}
