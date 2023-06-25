using System;
using System.Drawing;

namespace MinimumOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 16, num2 = 10;
            Console.WriteLine(MakeTheIntegerZero(num1, num2));
        }

        public static int MakeTheIntegerZero(int num1, int num2)
        {
            if (num2 >= num1) return -1;
            for (int i = 0; i <= 60; i++)
            {
                var diff = num1 - (long)i * num2;
                if (Count(diff) <= i && i <= diff)
                    return i;
            }
            return -1;
        }

        public static long Count(long num)
        {
            var count = 0L;
            while (num > 0)
            {

                count += num & 1;
                num >>= 1;
            }
            return count;
        }
    }
}
