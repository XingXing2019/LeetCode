using System;

namespace FindThePivotInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int PivotInteger(int n)
        {
            var sqrt = Math.Sqrt((double)(n * n + n) / 2);
            return sqrt == (int)sqrt ? (int)sqrt : -1;
        }
    }
}
