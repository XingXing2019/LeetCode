//设立一个长度为128整形数组代表哈希表(长度为128是因为char的阿斯特码为0-127)。
//设立一个maxLen代表最长字符串的个数，flag代表是否有中心单个字符。
//遍历字符串是哈希表所代表char的个数加一。
//遍历哈希表检查每个char个数的奇偶性，如为偶，则maxLen加上该字符的个数。如为奇maxLen加上该字符个数减一，并将flag设为一表示存在中心单个字符。
//返回maxLen加flag。
using System;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abccccdd";
            Console.WriteLine(LongestPalindrome(s));
        }
        static int LongestPalindrome(string s)
        {
            int[] charMap = new int[128];
            int maxLen = 0;
            int flag = 0;
            for (int i = 0; i < s.Length; i++)
            {
                charMap[s[i]]++;
            }
            for (int i = 0; i < 128; i++)
            {
                if (charMap[i] % 2 == 0)
                    maxLen += charMap[i];
                else
                {
                    maxLen += charMap[i] - 1;
                    flag = 1;
                }
            }
            return maxLen + flag;
        }
    }
}
