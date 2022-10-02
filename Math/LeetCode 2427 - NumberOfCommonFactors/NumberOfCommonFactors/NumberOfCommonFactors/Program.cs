using System;

namespace NumberOfCommonFactors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CommonFactors(int a, int b)
        {
            int res = 0, min = Math.Min(a, b);
            for (int i = 1; i <= min; i++)
            {
                if (a % i != 0 || b % i != 0) continue;
                res++;
            }
            return res;
        }
    }
}
