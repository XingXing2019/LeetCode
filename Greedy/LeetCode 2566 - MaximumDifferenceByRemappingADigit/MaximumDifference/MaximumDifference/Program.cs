using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinMaxDifference(99999));
        }

        public static int MinMaxDifference(int num)
        {
            return GenerateNum(num, 9) - GenerateNum(num, 0);
        }

        public static int GenerateNum(int num, int target)
        {
            var digits = new List<int>();
            int res = 0, copy = num;
            while (copy != 0)
            {
                digits.Add(copy % 10);
                copy /= 10;
            }
            if (target == 9 && digits.All(x => x == 9)) return num;
            var digit = target == 9 ? digits.Last(x => x != 9) : digits[^1];
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (digits[i] == digit)
                    digits[i] = target;
                res = res * 10 + digits[i];
            }
            return res;
        }
    }
}
