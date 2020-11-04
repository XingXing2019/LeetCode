//在n大于26的条件下，使n对26取余，并将结果计入tem，如果tem为零，证明这一位为Z，应将tem设为26，并令n减一。
//将tem所代表的的结果转化为字母存入res。并令n除等于26。
//循环结束后将现有的n转化为字母存入res。
using System;

namespace ExcelSheetColumnTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 78;
            Console.WriteLine(ConvertToTitle(n));
        }
        static string ConvertToTitle(int n)
        {
            var res = "";
            while (n > 26)
            {
                var temp = n % 26 - 1;
                if (temp < 0) temp += 26;
                res = (char)(temp + 'A') + res;
                if (n % 26 == 0) n--;
                n /= 26;
            }
            return (char)(n - 1 + 'A') + res;
        }
    }
}
