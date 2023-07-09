using System;
using System.Data;

namespace PartitionString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "111";
            Console.WriteLine(MinimumBeautifulSubstrings(s));
        }

        public static int MinimumBeautifulSubstrings(string s)
        {
            var res = int.MaxValue;
            DFS(s, 0, ref res);
            return res == int.MaxValue ? -1 : res;
        }

        public static void DFS(string s, int count, ref int res)
        {
            if (s.StartsWith('0'))
                return;
            if (s.Length == 0)
            {
                res = Math.Min(res, count);
                return;
            }
            for (int i = 1; i <= s.Length; i++)
            {
                var x = s.Substring(0, i);
                if (!IsPower5(x)) continue;
                DFS(s.Substring(i), count + 1, ref res);
            }
        }

        public static bool IsPower5(string s)
        {
            int x = 0, pow = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                x += (s[i] - '0') * pow;
                pow *= 2;
            }
            if (x == 0) return false;
            while (x != 1)
            {
                if (x % 5 != 0)
                    return false;
                x /= 5;
            }
            return true;
        }
    }
}
