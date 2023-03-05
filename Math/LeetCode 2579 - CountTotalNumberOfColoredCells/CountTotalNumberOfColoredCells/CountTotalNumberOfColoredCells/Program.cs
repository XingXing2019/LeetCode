using System;

namespace CountTotalNumberOfColoredCells
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long ColoredCells(int n)
        {
            return 1 + 2 * (long)n * (n - 1);
        }
    }
}
