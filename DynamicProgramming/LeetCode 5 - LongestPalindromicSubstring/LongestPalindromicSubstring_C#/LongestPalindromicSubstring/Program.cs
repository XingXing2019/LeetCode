//需要考虑子串长度有可能是奇数或者偶数。
//创建获取奇数子串的方法。创建res记录结果。从第二个元素开始遍历字符串，将遍历到的元素设为中心center。创建tem记录找到的回文串，初始值设为center所指向的元素。
//创建left和right指针分别指向center的左右两边的元素。在left和right没有出界的条件下分别向左右两边遍历。如果left和right指向的元素相同，则将他们拼入tem。
//当left和right指向元素不相同的时候停止本次遍历。无论如何使left减1，right加1，使遍历可以继续。
//比较tem和res长短，如果tem长于res，则将res替换为tem。当center遍历完整个字符串是返回res。
//创建获取偶数子串的方法。此方法认为center是由两个相同元素组成。所以需要找出两个相邻的相同元素。如相邻元素不相同，则跳过该次循环。
//其余思路和获取奇数子串方法相似。但需要从字符串第一个元素开始遍历，以免错过前两个元素相同的情况。
//而且需要将right设为center右边第二个元素。表示center是由两个相同元素组成。
//最后在主方法中调用两个方法找出最长的奇数串和偶数串，并返回较长的一个。
//需要注意字符串长度小于2的情况直接返回字符串。
//还需要注意字符串长度等于2的情况，要分别讨论两个字母是否相同的情况。
using System;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine(LongestPalindrome2(s));
        }
        static string LongestPalindrome(string s)
        {
            if (s.Length < 2)
                return s;
            if (s.Length == 2)
                return s[0] == s[1] ? s : s[0].ToString();
            string resOdd = getLongestOdd(s);
            string resEven = getLongestEven(s);
            return resOdd.Length > resEven.Length ? resOdd : resEven;
        }

        static string getLongestOdd(string s)
        {
            string res = "";
            for (int centre = 1; centre < s.Length - 1; centre++)
            {
                string tem = s[centre].ToString();
                int left = centre - 1;
                int right = centre + 1;
                while (left >= 0 && right <= s.Length - 1)
                {
                    if (s[left] == s[right])
                    {
                        tem += s[right];
                        tem = s[left] + tem;
                    }
                    else
                        break;
                    left--;
                    right++;
                }
                if (tem.Length > res.Length)
                    res = tem;
            }
            return res;
        }
        static string getLongestEven(string s)
        {
            string res = "";
            for (int center = 0; center < s.Length - 1; center++)
            {
                string tem = "";
                if (s[center] == s[center + 1])
                    tem = s[center].ToString() + s[center + 1];
                else
                    continue;
                int left = center - 1;
                int right = center + 2;
                while (left >= 0 && right <= s.Length - 1)
                {
                    if (s[left] == s[right])
                    {
                        tem += s[right];
                        tem = s[left] + tem;
                    }
                    else
                        break;
                    left--;
                    right++;
                }
                if (tem.Length > res.Length)
                    res = tem;
            }
            return res;
        }
        static string LongestPalindrome2(string s)
        {
            if (s.Length == 0)
                return s;
            string res = s.Substring(0, 1);
            for (int i = 0; i < s.Length; i++)
            {
                string s1 = getPalidromeByCenter(s, i, i);
                string s2 = getPalidromeByCenter(s, i, i + 1);
                string temp = s1.Length > s2.Length ? s1 : s2;
                res = res.Length > temp.Length ? res : temp;
            }
            return res;
        }
        static string getPalidromeByCenter(string s, int center1, int center2)
        {
            if (center2 >= s.Length) return "";
            if (s[center1] != s[center2]) return "";
            int k = 1;
            for (k = 1; k <= center1 && k < s.Length - center2; k++)
            {
                if (s[center1 - k] != s[center2 + k]) break;
            }
            return s.Substring(center1 - k + 1, center2 - center1 + 1 + 2 * (k - 1));
        }
    }
}
