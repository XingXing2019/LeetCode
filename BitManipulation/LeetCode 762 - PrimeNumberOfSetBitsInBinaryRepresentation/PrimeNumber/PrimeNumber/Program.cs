using System;
using System.Collections.Generic;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountPrimeSetBits(int L, int R)
        {
            var prime = new HashSet<int>{2, 3, 5, 7, 11, 13, 17, 19};
            int res = 0;
            for (int i = L; i <= R; i++)
            {
                int count = CountOnes(i);
                if (prime.Contains(count))
                    res++;
            }
            return res;
        }

        private int CountOnes(int num)
        {
            int count = 0;
            while (num != 0)
            {
                count += num & 1;
                num >>= 1;
            }
            return count;
        }
    }
}
