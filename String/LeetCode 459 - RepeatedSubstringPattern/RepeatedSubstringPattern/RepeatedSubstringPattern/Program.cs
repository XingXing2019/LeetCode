//如果一个字符串可以被n个子串组成，那么这个字符串一定可以被等分成n份，每份都一定一样。
//用i在2到字符串的长度之间循环，代表字符串可以被分成2份到其长度的份数。
//如果字符串不能被正好分成i份，则证明本次分法一定不能找到正确的子串，则直接跳过本次循环。
//否则设置len代表每个子串的长度，其值等于字符串的长度除以份数。设置subS代表每个子串的值，其值设为从字符串头截取len长度的子串。
//创建start指针代表每个子串的起始位置，其初始值设为len。代表从第二个子串开始比较
//在start不越界的条件下遍历每个子串，如果发现与subS不一样的子串，则终止遍历。
//遍历结束后，如果start可以正好等于字符串的长度，则证明每个子串都与subS一样，则返回true。
//如果每种分法都被试过后仍没有返回true，则证明没有一种分法可以符合条件，则返回false。
using System;

namespace RepeatedSubstringPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abab";
            Console.WriteLine(RepeatedSubstringPattern(s));
        }
        static bool RepeatedSubstringPattern(string s)
        {
            for (int i = 2; i <= s.Length; i++)
            {
                if (s.Length % i != 0)
                    continue;
                int len = s.Length / i;
                string subS = s.Substring(0, len);
                int start = len;
                while (start < s.Length)
                {
                    if (s.Substring(start, len) != subS)
                        break;
                    start += len;
                }
                if (start == s.Length)
                    return true;
            }
            return false;
        }
    }
}
