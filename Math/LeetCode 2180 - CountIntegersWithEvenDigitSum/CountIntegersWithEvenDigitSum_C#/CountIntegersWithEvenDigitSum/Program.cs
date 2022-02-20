using System;

namespace CountIntegersWithEvenDigitSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountEven(int num)
        {
            var res = 0;
            for (int i = 1; i <= num; i++)
            {
                if (IsValid(i))
                    res++;
            }
            return res;
        }

        public bool IsValid(int num)
        {
            var sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum % 2 == 0;
        }
    }
}
