using System;

namespace MinimumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumSum(int num)
        {
            var digits = new int[4];
            for (int i = 0; i < 4; i++)
            {
                digits[i] = num % 10;
                num /= 10;
            }
            Array.Sort(digits);
            return digits[0] * 10 + digits[2] + digits[1] * 10 + digits[3];
        }
    }
}
