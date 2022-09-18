using System;

namespace LengthOfTheLongest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LongestContinuousSubstring(string s)
        {
            int li = 0, hi = 0, res = 0;
            while (hi < s.Length)
            {
                if (li == hi || s[hi] - s[hi - 1] == 1)
                {
                    res = Math.Max(res, hi - li + 1);
                    hi++;
                }
                else
                    li = hi;
            }
            return res;
        }
    }
}
