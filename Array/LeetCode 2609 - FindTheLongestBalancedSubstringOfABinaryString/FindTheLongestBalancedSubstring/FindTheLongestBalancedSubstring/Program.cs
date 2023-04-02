using System;

namespace FindTheLongestBalancedSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "01000111";
            Console.WriteLine(FindTheLongestBalancedSubstring(s));
        }

        public static int FindTheLongestBalancedSubstring(string s)
        {
            int[] preZero = new int[s.Length], postOne = new int[s.Length];
            int zero = 0, one = 0, res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                preZero[i] = s[i] == '0' ? zero + 1 : zero;
                zero = s[i] == '0' ? zero + 1 : 0;
                one = s[^(i + 1)] == '1' ? one + 1 : 0;
                postOne[^(i + 1)] = one;
            }
            for (int i = 0; i < s.Length; i++)
                res = Math.Max(res, Math.Min(preZero[i], postOne[i]) * 2);
            return res;
        }
    }
}
