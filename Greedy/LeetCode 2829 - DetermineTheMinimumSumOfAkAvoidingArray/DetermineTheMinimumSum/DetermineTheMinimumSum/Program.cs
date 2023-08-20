using System;
using System.Collections.Generic;

namespace DetermineTheMinimumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5, k = 4;
            Console.WriteLine(MinimumSum(n, k));
        }

        public static int MinimumSum(int n, int k)
        {
            var banned = new HashSet<int>();
            for (int i = 1; i < k; i++)
            {
                if (k - i >= 0 && i < k - i)
                    banned.Add(k - i);
            }
            int res = 0, start = 1;
            while (n > 0)
            {
                if (!banned.Contains(start))
                {
                    res += start;
                    n--;
                }
                start++;
            }
            return res;
        }
    }
}
