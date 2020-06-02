using System;
using System.Collections.Generic;
using System.Linq;

namespace CountLargestGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CountLargestGroup(int n)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 1; i <= n; i++)
            {
                int sum = GetSum(i);
                if (!dict.ContainsKey(sum))
                    dict[sum] = 1;
                else
                    dict[sum]++;
            }
            int max = dict.Max(d => d.Value);
            return dict.Count(d => d.Value.Equals(max));
        }

        static int GetSum(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
