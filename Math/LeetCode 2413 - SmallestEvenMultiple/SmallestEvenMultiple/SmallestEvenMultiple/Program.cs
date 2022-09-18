using System;

namespace SmallestEvenMultiple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int SmallestEvenMultiple(int n)
        {
            return 2 * n / GCD(n, 2);
        }

        public int GCD(int num1, int num2)
        {
            if (num2 == 0)
                return num1;
            return GCD(num2, num1 % num2);
        }
    }
}
