//双指针，移动hi扩大包含字母的范围。当包含所有字母的时候将其及其之后的左右可能加入res。
//之后收缩li寻找所有依然很符合条件的区间。
using System;
using System.Linq;

namespace NumberofSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcabc";
            Console.WriteLine(NumberOfSubstrings(s));
        }
        static int NumberOfSubstrings(string s)
        {
            int[] record = new int[3];
            int res = 0;
            int li = 0, hi = 0;
            while (li < s.Length)
            {
                while (hi < s.Length)
                {
                    record[s[hi] - 'a']++;
                    if (record.All(r => r >= 1))
                    {
                        res += s.Length - hi;
                        hi++;
                        break;
                    }
                    hi++;
                }
                record[s[li] - 'a']--;
                li++;
                while (record.All(r => r >= 1))
                {
                    res += s.Length - hi + 1;
                    record[s[li] - 'a']--;
                    li++;
                }
            }
            return res;
        }
    }
}
