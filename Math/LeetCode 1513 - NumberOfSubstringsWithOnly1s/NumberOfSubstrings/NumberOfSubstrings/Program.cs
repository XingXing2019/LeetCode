//先用滑窗统计出连续1的长度和同样长度出现的次数。
//计算出每个长度的1有多少子串。可以使用动态规划将结果存入一个数组，方便之后取值。
//最后计算出总共有多少子串。
using System;
using System.Collections.Generic;

namespace NumberOfSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "111";
            Console.WriteLine(NumSub(s));
        }
        static int NumSub(string s)
        {
            int mod = 1_000_000_000 + 7;
            s += '0';
            var subStrings = new Dictionary<int, int>();
            var longest = 0;
            for (int left = 0; left < s.Length; left++)
            {
                if(s[left] == '0') continue;
                for (int right = left + 1; right < s.Length; right++)
                {
                    if(s[right] == '1') continue;
                    longest = Math.Max(longest, right - left);
                    if (!subStrings.ContainsKey(right - left))
                        subStrings[right - left] = 1;
                    else
                        subStrings[right - left]++;
                    left = right;
                    break;
                }
            }
            if (subStrings.Count == 0) return 0;
            var res = 0;
            var permutation = new int[longest + 1];
            permutation[1] = 1;
            for (int i = 2; i < permutation.Length; i++)
                permutation[i] = permutation[i - 1] % mod + i;
            foreach (var subString in subStrings)
                res += permutation[subString.Key] * subString.Value;
            return res;
        }
    }
}
