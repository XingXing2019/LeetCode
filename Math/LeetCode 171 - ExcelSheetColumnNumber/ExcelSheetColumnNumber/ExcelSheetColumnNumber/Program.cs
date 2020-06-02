//遍历s，令res等于当前res乘以26再加上当前字母代表的数字。
using System;

namespace ExcelSheetColumnNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "AB";
            Console.WriteLine(TitleToNumber(s));
        }
        static int TitleToNumber(string s)
        {
            int res = 0;
            for (int i = 0; i < s.Length; i++)
                res = res * 26 + (s[i] - 'A' + 1);
            return res;
        }
    }
}
