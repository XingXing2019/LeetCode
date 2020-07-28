//利用二分搜索。
using System;
using System.Collections.Generic;

namespace LongestRepeatingSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            //          012345678910
            string S = "aaaaa";
            //Console.WriteLine(SearchLength(4, S));
            Console.WriteLine(LongestRepeatingSubstring_BinarySearch(S));
        }
        static int LongestRepeatingSubstring_BruteForce(string S)
        {
            var res = 0;
            var candidates = new HashSet<string>();
            for (int i = 0; i < S.Length; i++)
            {
                for (int j = 1; j <= S.Length - i; j++)
                {
                    string temp = S.Substring(i, j);
                    if (candidates.Contains(temp))
                        res = Math.Max(res, temp.Length);
                    else
                        candidates.Add(temp);
                }
            }
            return res;
        }

        static int LongestRepeatingSubstring_BinarySearch(string S)
        {
            int li = 0, hi = S.Length, res = 0;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (!SearchLength(mid, S))
                    hi = mid;
                else
                {
                    li = mid + 1;
                    res = Math.Max(res, mid);
                }
            }
            return res;
        }

        static bool SearchLength(int len, string S)
        {
            var set = new HashSet<string>();
            for (int i = 0; i <= S.Length - len; i++)
            {
                string temp = S.Substring(i, len);
                if (set.Contains(temp))
                    return true;
                set.Add(temp);
            }
            return false;
        }
    }
}
