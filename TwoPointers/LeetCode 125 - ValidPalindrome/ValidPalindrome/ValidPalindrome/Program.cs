//使用left和right指针分别从字符串左右两端，向中间遍历。利用ASCII码来表示字母和数字。
//如果遇到非字母或数字的字符，则让相应指针移动一次，并跳过这次遍历。
//如果发现左右不同，则返回false。如果遍历结束后未返回，则返回true。
using System;

namespace ValidPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "0P";
            Console.WriteLine(IsPalindrome(s));
        }
        static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            string S = s.ToLower();
            while (left < right)
            {
                bool isLeftValid = (S[left] >= 97 && S[left] <= 122) || (S[left] >= 48 && S[left] <= 57);
                bool isRightValid = (S[right] >= 97 && S[right] <= 122) || (S[right] >= 48 && S[right] <= 57);
                if (isLeftValid && isRightValid)
                {
                    if (S[left] != S[right])
                        return false;
                    else
                    {
                        left++;
                        right--;
                    }
                }
                else if (!isLeftValid)
                {
                    left++;
                    continue;
                }
                else if (!isRightValid)
                {
                    right--;
                    continue;
                }
            }
            return true;
        }
    }
}
