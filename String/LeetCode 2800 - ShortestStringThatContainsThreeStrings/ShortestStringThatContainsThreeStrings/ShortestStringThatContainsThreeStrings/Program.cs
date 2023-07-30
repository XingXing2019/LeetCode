using System;
using System.Linq;

namespace ShortestStringThatContainsThreeStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "cab", b = "a", c = "b";
            Console.WriteLine(MinimumString(a, b, c));
        }

        public static string MinimumString(string a, string b, string c)
        {
            var abc = Join(Join(a, b), c);
            var acb = Join(Join(a, c), b);
            var bac = Join(Join(b, a), c);
            var bca = Join(Join(b, c), a);
            var cab = Join(Join(c, a), b);
            var cba = Join(Join(c, b), a);
            string[] strs = { abc, acb, bac, bca, cab, cba };
            return strs.OrderBy(x => x.Length).ThenBy(x => x).First();
        }

        public static string Join(string s1, string s2)
        {
            if (s1.Contains(s2)) return s1;
            if (s2.Contains(s1)) return s2;
            var max = 0;
            for (int i = 1; i <= Math.Min(s1.Length, s2.Length); i++)
            {
                var str1 = s1.Substring(s1.Length - i);
                var str2 = s2.Substring(0, i);
                if (str1 == str2)
                    max = Math.Max(max, i);
            }
            return s1 + s2.Substring(max);
        }
    }
}
