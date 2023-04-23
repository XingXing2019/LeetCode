using System;

namespace SumMultiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int SumOfMultiples(int n)
        {
            var res = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 5 != 0 && i % 7 != 0)
                    continue;
                res += i;
            }
            return res;
        }
    }
}
