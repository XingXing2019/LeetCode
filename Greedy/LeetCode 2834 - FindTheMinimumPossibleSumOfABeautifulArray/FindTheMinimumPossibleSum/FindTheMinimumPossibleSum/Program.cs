using System;
using System.Collections.Generic;

namespace FindTheMinimumPossibleSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MinimumPossibleSum(int n, int target)
        {
            var banned = new HashSet<int>();
            var start = 1;
            var sum = 0L;
            while (n != 0)
            {
                if (!banned.Contains(start))
                {
                    sum += start;
                    banned.Add(target - start);
                    n--;
                }
                start++;
            }
            return sum;
        }
    }
}
