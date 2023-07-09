
using System;

namespace SubstringWithLargestVariance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "aababbb";
            Console.WriteLine(LargestVariance(s));
        }

        public static int LargestVariance(string s)
        {
            var res = 0;
            for (int a = 0; a < 26; a++)
            {
                for (int b = 0; b < 26; b++)
                {
                    if (a == b) continue;
                    res = Math.Max(res, GetVariance(s, a, b));
                }
            }
            return res;
        }

        public static int GetVariance(string s, int a, int b)
        {
            int dp0 = 0, dp1 = int.MinValue, res = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] - 'a' == a)
                {
                    dp1++;
                    dp0++;
                }
                else if (s[i] - 'a' == b)
                {
                    dp1 = Math.Max(dp0, dp1) - 1;
                    dp0 = 0;
                }
                res = Math.Max(res, dp1);
            }
            return res;
        }
    }
}
