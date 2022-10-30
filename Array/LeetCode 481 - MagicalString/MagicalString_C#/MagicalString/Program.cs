using System;
using System.Linq;

namespace MagicalString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Console.WriteLine(MagicalString(n));
        }
        static int MagicalString(int n)
        {
            if (n == 0) return 0;
            if (n <= 3) return 1;
            int[] digits = new int[n];
            digits[0] = 1;
            digits[1] = 2;
            digits[2] = 2;
            int pointer = 2, tail = 3;
            while (tail < digits.Length)
            {
                int last = digits[tail - 1];
                for (int i = 0; i < digits[pointer] && tail < digits.Length; i++)
                    digits[tail++] = last ^ 3;
                pointer++;
            }
            return digits.Count(x => x == 1);
        }
    }
}
