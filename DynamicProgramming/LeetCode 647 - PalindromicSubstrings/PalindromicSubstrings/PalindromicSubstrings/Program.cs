//创建count记录回文串数量，初始值设为s的长度，因为每一个字母自己就是一个回文串。
//遍历字符串，假设回文串以一个字母为中心。创建left和right指针分别指向i的左右字母。让left和right分别向两边扩展，如果发现left和right所指向的字母相同，则count加一。当发现不相同时就停止遍历。
//再次遍历字符串，假设回文串以两个字母为中心(需做以此判断s[i]要等于s[i + 1])。
//创建left和right指针分别指向i的左边第一个字母和右边第二个字母。让left和right分别向两边扩展，如果发现left和right所指向的字母相同，则count加一。当发现不相同时就停止遍历。
using System;

namespace PalindromicSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abc";
            Console.WriteLine(CountSubstrings(s));
        }
        static int CountSubstrings(string s)
        {
            int count = s.Length;
            for (int i = 0; i < s.Length - 1; i++)
            {
                int left = i - 1;
                int right = i + 1;
                while (left >= 0 && right <= s.Length - 1)
                {
                    if (s[left] == s[right])
                        count++;
                    else
                        break;
                    left--;
                    right++;
                }
            }
            for (int i = 0; i < s.Length - 1; i++)
            {
                if(s[i] == s[i + 1])
                {
                    count++;
                    int left = i - 1;
                    int right = i + 2;
                    while (left >= 0 && right <= s.Length - 1)
                    {
                        if (s[left] == s[right])
                            count++;
                        else
                            break;
                        left--;
                        right++;
                    }
                }
            }
            return count;
        }
    }
}
