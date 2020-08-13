using System;
using System.Linq;

namespace SumOfDigitsInTheMinimumNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int SumOfDigits(int[] A)
        {
            var min = A.Min();
            var res = 0;
            while (min != 0)
            {
                res += min % 10;
                min /= 10;
            }
            return (res + 1) % 2;
        }
    }
}
