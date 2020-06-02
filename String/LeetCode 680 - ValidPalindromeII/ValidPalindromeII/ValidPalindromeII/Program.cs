//创建一个方法isVaild检查当前left和right指针之间的字符串是否是回文串。需要传进原始字符串和left与right指针。
//逻辑为在left和right不相遇的条件下遍历字符串，如果发现不一样的字符则返回false，否则遍历结束返回true。
//在主方法中创建left和right指针，分别指向字符串的头和尾。遍历字符串如果发现不一样的字符。
//则将当前left的下一个和当前right传入isVaild(相当于跳过了一次left)。并将当前left和right的前一个传入isValid(相当于跳过了一次right)
//拿到两个结果后，如有一个为真则返回true。只有当全为false的时候才返回false。可以用||操作符化简代码。
//遍历结束后如仍未返回false，则返回true。
using System;

namespace ValidPalindromeII
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abca";
            Console.WriteLine(ValidPalindrome(s));
        }
        static bool ValidPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                    return isValid(s, left + 1, right) || isValid(s, left, right - 1);
                left++;
                right--;
            }
            return true;
        }
        static bool isValid(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}
