using System;
using System.Collections.Generic;

namespace NumberOfSubstringsWithFixedRatio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "0110011";
            int num1 = 1, num2 = 2;
            Console.WriteLine(FixedRatio(s, num1, num2));
        }

        public static long FixedRatio(string s, int num1, int num2)
        {
            var count = new int[s.Length][];
            int zero = 0, one = 0;
            long res = 0;
            var dict = new Dictionary<long, int> { { 0, 1 } };
            for (int i = 0; i < s.Length; i++)
            {
                count[i] = new[] {zero, one};
                if (s[i] == '0')
                    count[i][0] = ++zero;
                else
                    count[i][1] = ++one;
                var diff = count[i][0] * num2 - count[i][1] * num1;
                if (!dict.ContainsKey(diff))
                    dict[diff] = 0;
                else
                    res += dict[diff];
                dict[diff]++;
            }
            return res;
        }
    }
}
