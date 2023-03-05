using System;
using System.Collections.Generic;

namespace SplitWithMinimumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int SplitNum(int num)
        {
            var digits = new List<int>();
            while (num != 0)
            {
                digits.Add(num % 10);
                num /= 10;
            }
            digits.Sort();
            int num1 = 0, num2 = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0)
                    num1 = num1 * 10 + digits[i];
                else
                    num2 = num2 * 10 + digits[i];
            }
            return num1 + num2;
        }
    }
}
