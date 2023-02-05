using System;
using System.Collections.Generic;

namespace MaximumNumberOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxCount(int[] banned, int n, int maxSum)
        {
            var set = new HashSet<int>(banned);
            int sum = 0, res = 0;
            for (int i = 1; i <= n; i++)
            {
                if (set.Contains(i)) continue;
                if (sum + i > maxSum)
                    return res;
                sum += i;
                res++;
            }
            return res;
        }
    }
}
