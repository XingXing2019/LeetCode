//创建长度为128的数组charMap记录字符出现的次数。
//创建begin指针指向字符串中第一个元素。创建maxLen记录最长子串的长度，初始值设为0。
//遍历字符串，如果当前字符没有在charMap中出现过，则将其在charMap中标记，然后判断当前i指针与begin指针的位置差，如果大于maxLen则替换maxLen。
//如果当前字符已经在charMap中出现过则需要移动begin指针，先将begin所指向的字符在charMap中取消标记，并且使begin指针向前移动一位。直到i指针所指向的字符在charMap中的标记被取消为止。
//begin指针移动停止后，将i指针指向的字符重新标记。
//当遍历结束后maxLen所记录的值即为结果。
using System;

namespace LongestSubstringWithoutRepeating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int LengthOfLongestSubstring(string s)
        {
            int[] charMap = new int[128];
            int begin = 0;
            int maxLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (charMap[s[i]] == 0)
                {
                    charMap[s[i]]++;
                    if ((i - begin + 1) > maxLen)
                        maxLen = i - begin + 1;
                }
                else
                {
                    while (charMap[s[i]] != 0)
                    {
                        charMap[s[begin]]--;
                        begin++;
                    }
                    charMap[s[i]]++;
                }
            }
            return maxLen;
        }
    }
}
