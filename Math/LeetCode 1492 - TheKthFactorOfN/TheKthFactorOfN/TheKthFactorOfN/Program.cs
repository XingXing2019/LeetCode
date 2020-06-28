using System;
using System.Collections.Generic;

namespace TheKthFactorOfN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int KthFactor(int n, int k)
        {
            var factorsSmall = new List<int>();
            var factorsLarge = new List<int>();
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    factorsSmall.Add(i);
                    factorsLarge.Add( n / i);
                }
            }
            for (int i = factorsLarge.Count - 1; i >= 0; i--)
                if(factorsLarge[i] != Math.Sqrt(n))
                    factorsSmall.Add(factorsLarge[i]);
            return factorsSmall.Count >= k ? factorsSmall[k - 1] : -1;
        }
    }
}
