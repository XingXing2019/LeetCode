using System;

namespace CountNumberOfHomogenousSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public int CountHomogenous(string s)
        {
            long res = 0;
            int li = 0, hi = 0, mod = 1_000_000_000 + 7;
            while (hi < s.Length)
            {
                while (hi < s.Length && s[li] == s[hi])
                    hi++;
                int len = hi - li;
                for (int i = 1; i <= len; i++)
                    res += i;
                li = hi;
            }
            return (int) (res % mod);
        }
    }
}
