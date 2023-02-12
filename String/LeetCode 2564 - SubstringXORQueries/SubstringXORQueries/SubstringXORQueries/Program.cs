using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubstringXORQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "1110";
            int[][] queries = { new[] { 4, 2 } };
            Console.WriteLine(SubstringXorQueries(s, queries));
        }

        public static int[][] SubstringXorQueries(string s, int[][] queries)
        {
            var res = new int[queries.Length][];
            var cache = new Dictionary<int, int[]>();
            var zero = s.IndexOf('0');
            for (int i = 0; i < queries.Length; i++)
            {
                var target = queries[i][0] ^ queries[i][1];
                if (cache.ContainsKey(target))
                {
                    res[i] = cache[target];
                }
                else
                {
                    res[i] = target == 0 ? new []{zero, zero} : FindSubString(s, GetLen(target), target);
                    cache[target] = res[i];
                }
            }
            return res;
        }

        public static int[] FindSubString(string s, int len, int target)
        {
            int cur = 0, index = 0, pow = (int)Math.Pow(2, len - 1);
            for (int i = 0; i < len; i++)
                cur = cur * 2 + (s[index++] - '0');
            if (cur == target)
                return new[] { index - len, index - 1 };
            while (index < s.Length)
            {
                cur -= pow * (s[index - len] - '0');
                cur = cur * 2 + s[index++] - '0';
                if (cur == target)
                    return new[] { index - len, index - 1 };
            }
            return new[] { -1, -1 };
        }

        public static int GetLen(int num)
        {
            var res = 0;
            while (num != 0)
            {
                res++;
                num /= 2;
            }
            return res;
        }
    }
}
