using System;

namespace ANumberAfterADoubleReversal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsSameAfterReversals(int num)
        {
            return num == 0 || num % 10 != 0;
        }
    }
}
