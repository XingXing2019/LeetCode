//创建GetDivisor方法得到字符串的最小循环子串。
//在种方法中调用GetDivisor方法得到str1和str2的最小循环子串divisor1和divisor2。如果两者不同则返回""。
//否则将最小循环子串不断复制，检查复制后的长度能否同时被str1和str2的长度整除，记录其中最大的子串长度。
//循环拼接，最终得到结果。
using System;

namespace GreatestCommonDivisorOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            string str2 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            Console.WriteLine(GcdOfStrings(str1, str2));
        }
        static string GcdOfStrings(string str1, string str2)
        {
            string divisor1 = GetDivisor(str1);
            string divisor2 = GetDivisor(str2);
            if (divisor1 == divisor2)
            {
                int len = divisor1.Length;
                int minLen = Math.Min(str1.Length, str2.Length);
                int times = 1;
                for (int i = 1; i <= minLen / len; i++)
                    if (str1.Length % (len * i) == 0 && str2.Length % (len * i) == 0)
                        times = i;
                string res = "";
                for (int i = 0; i < times; i++)
                    res += divisor1;
                return res;
            }
            else
                return "";
        }
        static string GetDivisor(string str)
        {
            string res = "";
            for (int len = 1; len <= str.Length; len++)
            {
                if (str.Length % len != 0)
                    continue;
                string tem = str.Substring(0, len);
                int pointer = 0;
                while (pointer <= str.Length - len)
                {
                    if (str.Substring(pointer, len) != tem)
                    {
                        tem = "";
                        break;
                    }
                    pointer += len;
                }
                if (tem != "")
                {
                    res = tem;
                    break;
                }
            }
            return res;
        }
    }
}
