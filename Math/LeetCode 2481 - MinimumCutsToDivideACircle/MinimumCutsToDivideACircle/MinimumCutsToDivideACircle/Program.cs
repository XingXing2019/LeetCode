using System;

namespace MinimumCutsToDivideACircle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfCuts(int n)
        {
            return n == 1 ? 0 : n % 2 == 0 ? n / 2 : n;
        }
    }
}
