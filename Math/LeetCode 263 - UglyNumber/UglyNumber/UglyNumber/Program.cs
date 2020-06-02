//在num对2，3，5取模不等于0的条件下分别使num除等于2，3，5。最后返回num是否等于1。
using System;

namespace UglyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 30;
            Console.WriteLine(IsUgly(num));
        }
        static bool IsUgly(int num)
        {
            if (num == 0)
                return false;
            while (num % 2 == 0)
                num /= 2;
            while (num % 3 == 0)
                num /= 3;
            while (num % 5 == 0)
                num /= 5;
            return num == 1;
        }
    }
}
