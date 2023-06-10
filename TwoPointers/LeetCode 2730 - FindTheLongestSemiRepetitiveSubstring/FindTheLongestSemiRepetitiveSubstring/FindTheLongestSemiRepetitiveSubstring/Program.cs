using System;

namespace FindTheLongestSemiRepetitiveSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "333";
            Console.WriteLine(LongestSemiRepetitiveSubstring(s));
        }

        public static int LongestSemiRepetitiveSubstring(string s)
        {
            int li = 0, hi = 0, res = 0;
            while (hi < s.Length)
            {
                while (li < hi && CountRepeat(s, li, hi) > 1)
                    li++;
                res = Math.Max(res, hi - li + 1);
                hi++;
            }
            return res;
        }

        public static int CountRepeat(string s, int li, int hi)
        {
            var res = 0;
            for (int i = li + 1; i <= hi; i++)
            {
                if (s[i] == s[i - 1])
                    res++;
            }
            return res;
        }
    }
}
