using System;
using System.Collections.Generic;
using System.Linq;

namespace Finding3DigitEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] FindEvenNumbers(int[] digits)
        {
            var dict = digits.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = new List<int>();
            for (int i = 100; i < 999; i++)
            {
                if (i % 2 != 0) continue;
                if (IsValid(i, dict))
                    res.Add(i);
            }
            return res.ToArray();
        }

        private bool IsValid(int num, Dictionary<int, int> dict)
        {
            var map = new Dictionary<int, int>();
            while (num != 0)
            {
                if (!dict.ContainsKey(num % 10))
                    return false;
                if (!map.ContainsKey(num % 10))
                    map[num % 10] = 0;
                map[num % 10]++;
                if (map[num % 10] > dict[num % 10])
                    return false;
                num /= 10;
            }
            return true;
        }
    }
}
