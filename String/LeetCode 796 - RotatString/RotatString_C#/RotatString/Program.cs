//遍历A，将A以遍历到的字母分割为左右两边(当前字母包含在左边)，如果将右边的字符串拼到左边字符串的前边后与B相同，则返回true。
using System;

namespace RotatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "abcde";
            string B = "abced";
            Console.WriteLine(RotateString(A, B));

        }
        static bool RotateString(string A, string B)
        {
            if (A == B)
                return true;
            for (int i = 0; i < A.Length; i++)
            {
                string tem1 = A.Substring(0, i + 1);
                string tem2 = A.Substring(i + 1);
                if (tem2 + tem1 == B)
                    return true;
            }
            return false;
        }
    }
}
