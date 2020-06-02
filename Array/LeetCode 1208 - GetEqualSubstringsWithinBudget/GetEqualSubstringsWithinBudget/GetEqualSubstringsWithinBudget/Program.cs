//创建li和hi两个指针做划窗操作。每次对maxCost左相应的变化，并在maxCost大于等于0时更新最大长度。
using System;

namespace GetEqualSubstringsWithinBudget
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcd";
            string t = "cdef";
            int maxCost = 3;
            Console.WriteLine(EqualSubstring(s, t, maxCost));
        }
        static int EqualSubstring(string s, string t, int maxCost)
        {
            int li = 0, hi = 0;
            maxCost -= Math.Abs(s[li] - t[li]);
            int maxLen = 0;
            while (hi < s.Length)
            {
                if (maxCost >= 0)
                {
                    maxLen = Math.Max(maxLen, hi - li + 1);
                    hi++;
                    if (hi > s.Length - 1)
                        break;
                    maxCost -= Math.Abs(s[hi] - t[hi]);
                }
                else
                {
                    maxCost += Math.Abs(s[li] - t[li]);
                    li++;
                }
            }
            return maxLen;
        }
    }
}
