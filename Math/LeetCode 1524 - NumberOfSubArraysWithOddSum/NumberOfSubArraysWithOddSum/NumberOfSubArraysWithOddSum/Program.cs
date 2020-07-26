using System;

namespace NumberOfSubArraysWithOddSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumOfSubarrays(int[] arr)
        {
            int even = 0, odd = 0;
            int sum = 0, count = 0, mod = 1_000_000_000 + 7;
            foreach (var num in arr)
            {
                sum += num;
                if (sum % 2 != 0)
                {
                    count = (count + even + 1) % mod;
                    odd++;
                }
                else
                {
                    count = (count + odd) % mod;
                    even++;
                }
            }
            return count;
        }
    }
}
