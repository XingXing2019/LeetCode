using System;

namespace KItemsWithTheMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
        {
            return Math.Min(numOnes, k) - Math.Max(0, k - numOnes - numZeros);
        }
    }
}
