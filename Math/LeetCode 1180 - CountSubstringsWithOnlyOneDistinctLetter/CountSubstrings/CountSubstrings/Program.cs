using System;
using System.Collections.Generic;

namespace CountSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CountLetters(string S)
        {
            var distinctSubs= new List<int>();
            int li = 0, hi = 0;
            while (hi < S.Length)
            {
                if (S[li] == S[hi])
                    hi++;
                else
                {
                    distinctSubs.Add(hi - li);
                    li = hi;
                }
            }
            distinctSubs.Add(hi - li);
            var res = 0;
            foreach (var distinctSub in distinctSubs)
                res += (1 + distinctSub) * distinctSub / 2;
            return res;
        }
    }
}
